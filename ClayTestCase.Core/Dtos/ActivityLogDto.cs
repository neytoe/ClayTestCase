using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Dtos
{
    public class ActivityLogDto
    {
        public int DoorId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeRole { get; set; }
        public bool IsAccessGranted { get; set; }
        public DateTime Date { get; set; }
    }
}
