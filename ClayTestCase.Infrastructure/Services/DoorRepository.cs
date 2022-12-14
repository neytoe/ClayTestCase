using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
    public class DoorRepository : BaseRepository<Door>, IDoorRepository
    {
        public DoorRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }
    }
}
