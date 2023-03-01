using JWTEmployeePortal.DAL.Entities;
using JWTEmployeePortal.DAL.Repositories;
using JWTEmployeePortal.Extensions;
using JWTEmployeePortal.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTEmployeePortal.Services
{
    public class EmpoyeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IConfiguration _config;

        public EmpoyeeService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            _config = serviceProvider.GetRequiredService<IConfiguration>();

        }

        public async Task<WriteLogModel> Add(RegisterRequestModel registerEmployee)
        {
            var item = ConvertModels(registerEmployee);
            return await _repository.Add(item);
        }

        public async Task<WriteLogModel> Login(LoginEmployee login)
        {

            var model = await _repository.Login(login);
            if (model.Code.Equals("200"))
            {
                Console.WriteLine(GenerateJSONWebToken());
            }

            return model;

        }
        private RegisterEmployee ConvertModels(RegisterRequestModel registerEmployee)
        {
            RegisterEmployee register = new RegisterEmployee()
            {
                CreatedDate = DateTime.Now,
                Email = registerEmployee.Email,
                isLoggedIn = false,
                Name = registerEmployee.Name,
                Password = Encoding.ASCII.GetBytes(registerEmployee.Password)
            };
            return register;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JWT:ValidIssuer"],
              _config["JWT:ValidIssuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
