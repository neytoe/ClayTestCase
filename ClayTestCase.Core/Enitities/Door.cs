using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Enitities
{
    public class Door
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public ICollection<AccessRoles> AccessRoles { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
