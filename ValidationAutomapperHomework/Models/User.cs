using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ValidationAutomapperHomework.Models
{
	public class User
	{
        public int Id { get; set; }
		public string? Usernaame { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
        public string? Region { get; set; }
    }
}
