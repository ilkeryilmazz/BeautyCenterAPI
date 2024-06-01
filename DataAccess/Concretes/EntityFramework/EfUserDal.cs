using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BaseDbContext>, IUserDal
    {
        public List<User> GetEmployeeWithServiceByServiceId(int serviceId)
        {
            using (var context = new BaseDbContext())
            {
                var result = from user in context.Users
                             where user.IsEmployee == true
                             join employeeService in context.EmployeeServices on user.Id equals employeeService.EmployeeId
                             where employeeService.ServiceId == serviceId
                             select user;

                return result.ToList();
            }
           
        }
    }
}
