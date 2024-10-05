using BackEndTask.Data.Entities;

namespace BackEndTask.Repositories
{
    public interface IZoneRepository
    {
        Task AddZoneAsync(Zone zone);
    }
}
