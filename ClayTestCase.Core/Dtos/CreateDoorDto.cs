using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Dtos
{
    public class CreateDoorDto
    {
        public string Name { get; set; }
        public ICollection<AccessRole> AccessRoles { get; set; }
    }
}
