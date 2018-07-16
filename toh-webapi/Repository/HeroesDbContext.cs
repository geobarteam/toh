using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TOHWebApi.Model;

namespace TOHWebApi.Repository
{
    public class HeroesDbContext : DbContext
    {
        public HeroesDbContext(DbContextOptions<HeroesDbContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().ToTable("heroes");
           
        }
    }
}
