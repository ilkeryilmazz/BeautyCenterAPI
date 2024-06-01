using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts
{
    public interface IServiceService
    {
        IDataResult<Service> Add(Service service, IFormFile image);
        IDataResult<Service> Delete(Service service);
        IDataResult<Service> Update(Service service);
        IDataResult<List<Service>> GetAllServices();
    
    }
}
