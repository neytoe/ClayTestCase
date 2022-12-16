using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Enitities
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int DoorId { get; set; }
        public int EmployeeId { get; set; } 
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public DateTime Date { get; set; }


    }
}
