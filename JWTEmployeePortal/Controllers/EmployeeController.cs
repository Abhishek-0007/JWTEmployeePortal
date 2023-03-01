using JWTEmployeePortal.DAL.Entities;
using JWTEmployeePortal.Models;
using JWTEmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using JWTEmployeePortal.Extensions;

namespace JWTEmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IServiceProvider service)
        {
            _service = service.GetRequiredService<IEmployeeService>();
        }

        [HttpPost]
        [Route("Register")]
        public Task<WriteLogModel> Add(RegisterRequestModel registerEmployee)
        {
            return _service.Add(registerEmployee);
        }

        [HttpPost]
        [Route("Login")]
        public Task<WriteLogModel> Login(LoginEmployee loginEmployee)
        {
            return _service.Login(loginEmployee);
        }
    }
}
