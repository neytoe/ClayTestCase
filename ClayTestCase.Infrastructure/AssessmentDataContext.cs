using ClayTestCase.Core.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure
{
    public class AssessmentDataContext : DbContext
    {
        public AssessmentDataContext(DbContextOptions<AssessmentDataContext> options) : base(options)
        {
        }

        public DbSet<AccessRoles> AccessRoles { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
