using Core.DataAccess;
using Entities.Concretes;
using Entities.Dtos;

namespace DataAccess.Abstracts
{
    public interface IReservationDal : IEntityRepository<Reservation>
    {
        List<ReservationDetailDtoForAdmin> GetAllReservationDetailDto();
        List<ReservationDetailDtoForAdmin> GetAllReservationDetailByCustomerId(int id);
        List<ReservationDetailDtoForAdmin> GetAllReservationDetailByEmployeeId(int id);
    }
}
