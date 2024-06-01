using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Reservation : IEntity
    {
        public int Id{ get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
    }
}
