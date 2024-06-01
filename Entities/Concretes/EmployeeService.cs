using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class EmployeeService:IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
    }
}
