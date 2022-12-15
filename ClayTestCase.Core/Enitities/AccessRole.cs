using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Enitities
{
    public class AccessRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<DoorAccessRole> DoorAccessRoles { get; set; }
    }
}
