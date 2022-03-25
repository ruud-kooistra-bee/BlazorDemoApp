using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public int RoleId { get; set; } = 0;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
