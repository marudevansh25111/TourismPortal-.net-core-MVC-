using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Tourism_Portal.Models;
namespace Online_Tourism_Portal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Registration> Registration { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
