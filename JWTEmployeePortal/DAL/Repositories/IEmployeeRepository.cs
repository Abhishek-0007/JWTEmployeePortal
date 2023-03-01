using JWTEmployeePortal.DAL.Entities;
using JWTEmployeePortal.Models;

namespace JWTEmployeePortal.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<WriteLogModel> Add(RegisterEmployee registerEmployee);

        public Task<WriteLogModel> Login(LoginEmployee login);

    }
}
