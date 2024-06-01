using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Entities.Dtos;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfReservationDal : EfEntityRepositoryBase<Reservation, BaseDbContext>, IReservationDal
    {
        public List<ReservationDetailDtoForAdmin> GetAllReservationDetailByCustomerId(int id)
        {
            using (var context = new BaseDbContext())
            {
                var result = from reservation in context.Reservations
                             join employee in context.Users on reservation.EmployeeId equals employee.Id
                             join user in context.Users on reservation.CustomerId equals user.Id
                             join service in context.Services on reservation.ServiceId equals service.Id
                             where reservation.CustomerId == id
                             select new ReservationDetailDtoForAdmin
                             {
                                 Service = service.Name,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 EmployeeName = employee.FirstName + " " + employee.LastName,
                                 Date = reservation.Date,
                                 Id = reservation.Id

                             };

                return result.ToList();
            }
        }

        public List<ReservationDetailDtoForAdmin> GetAllReservationDetailByEmployeeId(int id)
        {
            using (var context = new BaseDbContext())
            {
                var result = from reservation in context.Reservations
                             join employee in context.Users on reservation.EmployeeId equals employee.Id
                             join user in context.Users on reservation.CustomerId equals user.Id
                             join service in context.Services on reservation.ServiceId equals service.Id
                             where reservation.EmployeeId == id
                             select new ReservationDetailDtoForAdmin
                             {
                                 Service = service.Name,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 EmployeeName = employee.FirstName + " " + employee.LastName,
                                 Date = reservation.Date,
                                 Id = reservation.Id

                             };

                return result.ToList();
            }
        }

        public List<ReservationDetailDtoForAdmin> GetAllReservationDetailDto()
        {
            using (var context = new BaseDbContext())
            {
                var result = from reservation in context.Reservations
                             join employee in context.Users on reservation.EmployeeId equals employee.Id
                             join user in context.Users on reservation.CustomerId equals user.Id
                             join service in context.Services on reservation.ServiceId equals service.Id
                             select new ReservationDetailDtoForAdmin
                             {
                                 Service = service.Name,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 EmployeeName = employee.FirstName + " " + employee.LastName,
                                 Date = reservation.Date,
                                 Id = reservation.Id

                             };

                return result.ToList();
            }
        }
    }
}
