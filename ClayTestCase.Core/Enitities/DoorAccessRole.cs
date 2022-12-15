using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Enitities
{
    public class DoorAccessRole
    {
        public int Id { get; set; }
        public Door Door { get; set; }
        public int DoorId { get; set; }

        public int AccessRoleId { get; set; }
        public AccessRole AccessRole { get; set; }
    }
}
