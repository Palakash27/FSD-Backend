using Microsoft.EntityFrameworkCore;
using BackEndTask.Data.Entities;
using BackEndTask.DTOs;

namespace BackEndTask.Data
{
    public class ExcelProcessorDbContext : DbContext
    {
        public ExcelProcessorDbContext(DbContextOptions<ExcelProcessorDbContext> options)
           : base(options) { }

        public DbSet<ClickZone> ClickZones { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneClickCountDTO> ZoneClickCountDTO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClickZone>().ToTable("ClickZone");
            modelBuilder.Entity<Zone>().ToTable("Zone");
            modelBuilder.Entity<ZoneClickCountDTO>().HasNoKey();
        }
    }
}
