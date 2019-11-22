﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UrenProjectQien.Models
{
    public class UrenProjectQienContext : IdentityDbContext<IdentityUser>
    {
        public UrenProjectQienContext(DbContextOptions<UrenProjectQienContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<HoursPerDay> HoursPerDays { get; set; }

        public DbSet<HoursForm> HoursForms { get; set; }

        public DbSet<AccountIdentity> AccountIdentity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}