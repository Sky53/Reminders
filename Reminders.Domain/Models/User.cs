using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Reminders.Domain.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? IsDeleted { get; set; }

        //public Event? Event { get; set; }
    }
}
