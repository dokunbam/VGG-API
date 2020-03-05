using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGG_API.Entities;

namespace VGG_API.Data
{
    public class ApiContext : IdentityDbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<User> NewUsers { get; set; }
        public DbSet <Project> Projects { get; set; }
        public DbSet<Entities.Action> Actions { get; set; }
    }
        
}

