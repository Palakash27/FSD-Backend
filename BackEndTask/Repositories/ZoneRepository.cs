using BackEndTask.Data.Entities;
using BackEndTask.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly ExcelProcessorDbContext _context;

        public ZoneRepository(ExcelProcessorDbContext context)
        {
            _context = context;
        }

        public async Task AddZoneAsync(Zone zone)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Enable IDENTITY_INSERT for Zone
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Zone] ON");
                    await _context.Zones.AddAsync(zone);
                    await _context.SaveChangesAsync();
                    // Disable IDENTITY_INSERT for Zone
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Zone] OFF");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error in ZoneRepository: AddZoneAsync -> " + ex.Message);
                }
            }
        }
    }
}
