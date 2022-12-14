using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Enitities
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Door> Doors { get; set; }
    }
}
