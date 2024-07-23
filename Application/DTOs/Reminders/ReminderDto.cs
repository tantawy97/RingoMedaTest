using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reminders
{
    public class ReminderDto
    {
        public string Name { get; set; } = null!;
        public DateTime RemindTime { get; set; }
    }
}
