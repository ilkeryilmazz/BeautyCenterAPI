using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Abstracts
{
    public interface IReservationService
    {
        IDataResult<Reservation> Add(Reservation reservation);
        IDataResult<Reservation> Update(Reservation reservation);
        IDataResult<Reservation> Delete(int id);
        IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailByCustomerId(int customerId);
        IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailByEmployeeId(int employeeId);
        IDataResult<List<Reservation>> GetAll();
        IDataResult<List<Reservation>> GetAllByEmployeerId(int employeerId);
        IDataResult<List<Reservation>> GetAllByCustomerId(int customerId);
        IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailDto();
    }
}
