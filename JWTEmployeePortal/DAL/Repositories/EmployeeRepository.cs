using JWTEmployeePortal.DAL.DbContexts;
using JWTEmployeePortal.DAL.Entities;
using JWTEmployeePortal.Models;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTEmployeePortal.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public async Task<WriteLogModel> Add(RegisterEmployee registerEmployee)
        {
           if(_dbContext.Employees.Contains(registerEmployee)) 
            {
                return new WriteLogModel()
                {
                    Code = "400",
                    Message = "Already Exists"
                };
            }
            else
            {
                await _dbContext.AddAsync(registerEmployee);

                await _dbContext.SaveChangesAsync();

                return new WriteLogModel()
                {
                    Code = "200",
                    Message = "Added Successfully"
                };
            }
            


        }


        public async Task<WriteLogModel> Login(LoginEmployee login)
        {
            var item = await _dbContext.Employees.Where(t => t.Email.Equals(login.Email) &&
                                                            t.Password.Equals(Encoding.ASCII.GetBytes(login.Password))).FirstOrDefaultAsync();


            if (item is null)
            {
                return new WriteLogModel()
                {
                    Code = "400",
                    Message = "User does not Exists"
                };
            }
            else if (item.isLoggedIn == true)
            {
                return new WriteLogModel()
                {
                    Code = "200",
                    Message = "User already logged in"
                };
            }
            else
            {
                item.isLoggedIn = true;

                await _dbContext.SaveChangesAsync();

                return new WriteLogModel()
                {
                    Code = "200",
                    Message = "Logged in Successfully"
                };
            }
        }

    }
}
