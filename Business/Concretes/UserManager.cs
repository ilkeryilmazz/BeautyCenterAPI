using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Delete(int id)
        {
            var data = _userDal.Get(c=>c.Id==id).GetAwaiter().GetResult();
            var deletedUser = _userDal.Delete(data);
            return new SuccessDataResult<User>(data, "Kullanıcı silindi.");
        }

        public IDataResult<List<User>> GetAllEmployees()
        {
            var data = _userDal.GetAll(c => c.IsEmployee == true).GetAwaiter().GetResult();
            return new SuccessDataResult<List<User>>(data,"Tüm çalışanlar listelendi.");
        }

        public IDataResult<User> GetById(int id)
        {
            var data = _userDal.Get(c => c.Id == id).GetAwaiter().GetResult();
            return new SuccessDataResult<User>(data, "Tüm çalışanlar listelendi.");
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var data = _userDal.Get(c => c.Email == mail).GetAwaiter().GetResult();
            return new SuccessDataResult<User>(data);
        }

        public IDataResult<List<User>> GetEmployeeWithServiceByServiceId(int serviceId)
        {
            var data = _userDal.GetEmployeeWithServiceByServiceId(serviceId);
            return new SuccessDataResult<List<User>>(data);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = GetByMail(userForLoginDto.Email).Data;
            if (user!=null && userForLoginDto.Password == user.Password)
            {
                return new SuccessDataResult<User>(user,"Giriş Başarılı.");
            }
            return new ErrorDataResult<User>("E-posta veya şifre hatalı.");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, IFormFile image)
        {
            User user = new User() {IsEmployee=false,IsAdmin=false,IsCustomer=true,FirstName=userForRegisterDto.FirstName,LastName=userForRegisterDto.LastName,Email=userForRegisterDto.Email,Password=userForRegisterDto.Password };

            if (GetByMail(userForRegisterDto.Email).Data != null)
            {
                return new ErrorDataResult<User>("Bu e-posta adresi kullanılıyor.");
            }
            var imagePath = FileHelper.Upload(image, PathConstants.ImagesPath);
            user.ImagePath = imagePath;
            var registeredUser = _userDal.Add(user).GetAwaiter().GetResult();
            return new SuccessDataResult<User>(user);

        }

        public IDataResult<User> RegisterEmployee(UserForRegisterDto userForRegisterDto, IFormFile image)
        {
            User user = new User() { IsEmployee = true, IsAdmin = false, IsCustomer = false, FirstName = userForRegisterDto.FirstName, LastName = userForRegisterDto.LastName, Email = userForRegisterDto.Email, Password = userForRegisterDto.Password };

            if (GetByMail(userForRegisterDto.Email).Data != null)
            {
                return new ErrorDataResult<User>("Bu e-posta adresi kullanılıyor.");
            }
            var imagePath = FileHelper.Upload(image, PathConstants.ImagesPath);
            user.ImagePath = imagePath;
            var registeredUser = _userDal.Add(user).GetAwaiter().GetResult();
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Update(UserForRegisterDto userForRegisterDto, IFormFile? image)
        {
           
            var user = _userDal.Get(c=>c.Id == userForRegisterDto.Id).GetAwaiter().GetResult();
            var newPath = user.ImagePath;
            if (image!=null)
            {
               newPath = FileHelper.Update(image, PathConstants.ImagesPath, PathConstants.ImagesPath + user.ImagePath);
            }
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName=userForRegisterDto.LastName;
            user.Email = userForRegisterDto.Email;
            user.Password= userForRegisterDto.Password;
            user.ImagePath = newPath;
            var updatedUser = _userDal.Update(user);
            return new SuccessDataResult<User>(user);
        }
    }
}
