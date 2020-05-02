using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reminders.Business.AutoMapper.User
{
    public class UserRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string? SecondName { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
    }
}
