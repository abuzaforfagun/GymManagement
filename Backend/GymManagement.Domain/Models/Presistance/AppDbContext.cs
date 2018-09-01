using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GymManagement.Domain.Models.Presistance
{
    public class AppDbContext : DbContext
    {
        private IConfiguration Configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {
                
        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("GymDb"));
            }
        }
    }
}
