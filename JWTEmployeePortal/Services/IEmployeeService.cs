using JWTEmployeePortal.DAL.Entities;
using JWTEmployeePortal.Models;

namespace JWTEmployeePortal.Services
{
    public interface IEmployeeService
    {
        public Task<WriteLogModel> Add(RegisterRequestModel registerEmployee);

        public Task<WriteLogModel> Login(LoginEmployee login);


    }
}
