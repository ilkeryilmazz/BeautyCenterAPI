using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Entites.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string ImagePath { get; set; }
        public double Yen { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public bool Status { get; set; }
        public bool? IsSub { get; set; }
    }
}