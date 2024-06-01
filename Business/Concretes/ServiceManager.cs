using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IDataResult<Service> Add(Service service, IFormFile image)
        {
            var imagePath=FileHelper.Upload(image,PathConstants.ImagesPath);
            service.ImagePath = imagePath;
            var data = _serviceDal.Add(service).GetAwaiter().GetResult();

            return new SuccessDataResult<Service>(data,"Servis eklendi.");
        }

        public IDataResult<Service> Delete(Service service)
        {
             var data = _serviceDal.Add(service).GetAwaiter().GetResult();

            return new SuccessDataResult<Service>(data,"Servis eklendi.");
        }

        public IDataResult<List<Service>> GetAllServices()
        {
            var data = _serviceDal.GetAll().GetAwaiter().GetResult();
            return new SuccessDataResult<List<Service>>(data, "Servis eklendi.");
        }

        public IDataResult<Service> Update(Service service)
        {
            var data = _serviceDal.Update(service).GetAwaiter().GetResult();

            return new SuccessDataResult<Service>(data, "Servis eklendi.");
        }
    }
}
