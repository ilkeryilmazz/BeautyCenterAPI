using Business.Abstracts;
using Castle.Core.Resource;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Concretes
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public IDataResult<Reservation> Add(Reservation reservation)
        {
            var data = _reservationDal.Add(reservation).GetAwaiter().GetResult();
            return new SuccessDataResult<Reservation>(reservation,"Rezarvasyon başarıyla kaydedildi");
        }

        public IDataResult<Reservation> Delete(int id)
        {
            var data = _reservationDal.Get(c=>c.Id == id).GetAwaiter().GetResult();
            var deletedData = _reservationDal.Delete(data).GetAwaiter().GetResult();
            return new SuccessDataResult<Reservation>(deletedData, "Rezarvasyon başarıyla silindi.");
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            var data = _reservationDal.GetAll().GetAwaiter().GetResult();
            return new SuccessDataResult<List<Reservation>>(data, "Rezarvasyonlar başarıyla listelendi.");
        }

        public IDataResult<List<Reservation>> GetAllByCustomerId(int customerId)
        {
            var data = _reservationDal.GetAll(c=>c.CustomerId==customerId).GetAwaiter().GetResult();
            return new SuccessDataResult<List<Reservation>>(data, "Rezarvasyonlar başarıyla listelendi.");
        }

        public IDataResult<List<Reservation>> GetAllByEmployeerId(int employeerId)
        {
            var data = _reservationDal.GetAll(c => c.EmployeeId == employeerId).GetAwaiter().GetResult();
            return new SuccessDataResult<List<Reservation>>(data, "Rezarvasyonlar başarıyla listelendi.");
        }

        public IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailByCustomerId(int customerId)
        {
            var data = _reservationDal.GetAllReservationDetailByCustomerId(customerId);
            return new SuccessDataResult<List<ReservationDetailDtoForAdmin>>(data);
        }

        public IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailByEmployeeId(int employeeId)
        {
            var data = _reservationDal.GetAllReservationDetailByEmployeeId(employeeId);
            return new SuccessDataResult<List<ReservationDetailDtoForAdmin>>(data);
        }

        public IDataResult<List<ReservationDetailDtoForAdmin>> GetAllReservationDetailDto()
        {
            var data = _reservationDal.GetAllReservationDetailDto();
            return new SuccessDataResult<List<ReservationDetailDtoForAdmin>>(data);
        }

        public IDataResult<Reservation> Update(Reservation reservation)
        {
            var data = _reservationDal.Update(reservation).GetAwaiter().GetResult();
            return new SuccessDataResult<Reservation>(data, "Rezarvasyon başarıyla güncellendi");
        }
    }
}
