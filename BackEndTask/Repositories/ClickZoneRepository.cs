using BackEndTask.Data.Entities;
using BackEndTask.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Repositories
{
    public class ClickZoneRepository : IClickZoneRepository
    {
        private readonly ExcelProcessorDbContext _context;

        public ClickZoneRepository(ExcelProcessorDbContext context)
        {
            _context = context;
        }

        public async Task AddClickZoneAsync(ClickZone clickZone)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Enable IDENTITY_INSERT for ClickZone
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ClickZone] ON");
                    await _context.ClickZones.AddAsync(clickZone);
                    await _context.SaveChangesAsync();
                    // Disable IDENTITY_INSERT for ClickZone
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ClickZone] OFF");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error in ClickZoneRepository: AddClickZoneAsync -> " + ex.Message);
                }
            }
        }
    }
}
