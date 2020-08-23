using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneSignalTask.Core;

namespace OneSignalTask.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<App> Apps { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
