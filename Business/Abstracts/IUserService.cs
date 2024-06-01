using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IDataResult<User> Delete(int id);
        IDataResult<User> Update(UserForRegisterDto userForRegisterDto, IFormFile? image);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, IFormFile image);
        IDataResult<User> RegisterEmployee(UserForRegisterDto userForRegisterDto, IFormFile image);
        IDataResult<List<User>> GetAllEmployees();
        IDataResult<User> GetByMail(string mail);
        IDataResult<User> GetById(int id);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<List<User>> GetEmployeeWithServiceByServiceId(int serviceId);
    }
}
