
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeWidgetBusinessModels.Data.Entities;

namespace AcmeWidgetCompanyEmployeeActivity.Data
{
    public class AcmeDBContext: DbContext
    {
        public AcmeDBContext(DbContextOptions<AcmeDBContext> options): base(options)
        { }
        public DbSet<Activity> ActivityTable { get; set; }
        public  DbSet<Registration> RegistrationTable { get; set; }

    }
}
