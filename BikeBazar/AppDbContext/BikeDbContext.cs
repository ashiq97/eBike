using BikeBazar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeBazar.AppDbContext
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options):base(options)
        {
            
        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<BikeModel> BikeModels { get; set; }
    }
}
