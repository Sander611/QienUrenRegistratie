using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.DataContext
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<HoursPerDay> HoursPerDays { get; set; }

        public DbSet<HoursForm> HoursForms { get; set; }
    }
}
