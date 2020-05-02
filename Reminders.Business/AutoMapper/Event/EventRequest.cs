using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reminders.Business.AutoMapper.Event
{
    public class EventRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
    }
}
