using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Helper
{
    public class ModelReturnHelper
    {
        public static IEnumerable<ActivityLog> ReturnDoors() {

            return new List<ActivityLog> {
                new ActivityLog
                {
                    Id = 1,
                    DoorId = 1,
                    EmployeeEmail = "hankz@gmail.com",
                    EmployeeId = 2,
                    EmployeeRole = "Employee",
                    Date= DateTime.Now,
                    IsAccessGranted = true,
                },
                  new ActivityLog
                {
                    Id = 2,
                    DoorId = 3,
                    EmployeeEmail = "haz@gmail.com",
                    EmployeeId = 7,
                    EmployeeRole = "Admin",
                    Date= DateTime.Now,
                    IsAccessGranted = true,
                },  new ActivityLog
                {
                    Id = 3,
                    DoorId = 1,
                    EmployeeEmail = "hank@gmail.com",
                    EmployeeId = 2,
                    EmployeeRole = "Employee",
                    Date= DateTime.Now,
                    IsAccessGranted = true,
                }
            };
        }
    }
}
