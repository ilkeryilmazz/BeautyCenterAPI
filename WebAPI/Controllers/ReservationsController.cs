using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost("Add")]
        public IActionResult Add(Reservation reservation)
        {
            var result = _reservationService.Add(reservation);
            if (result.Success) { 
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Reservation reservation)
        {
            var result = _reservationService.Update(reservation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _reservationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        

        [HttpGet("GetAllReservationDetailDto")]
        public IActionResult GetAllReservationDetailDto()
        {
            var result = _reservationService.GetAllReservationDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("GetAllReservationDetailByCustomerId")]
        public IActionResult GetAllReservationDetailByCustomerId(int customerId)
        {
            var result = _reservationService.GetAllReservationDetailByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllReservationDetailByEmployeeId")]
        public IActionResult GetAllReservationDetailByEmployeeId(int employeeId)
        {
            var result = _reservationService.GetAllReservationDetailByEmployeeId(employeeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _reservationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByEmployeerId")]
        public IActionResult GetAllByEmployeerId(int employeerId)
        {
            var result = _reservationService.GetAllByEmployeerId(employeerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByCustomerId")]
        public IActionResult GetAllByCustomerId(int customerId)
        {
            var result = _reservationService.GetAllByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
