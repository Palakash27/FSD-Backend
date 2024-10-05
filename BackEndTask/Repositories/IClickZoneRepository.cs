using BackEndTask.Data.Entities;

namespace BackEndTask.Repositories
{
    public interface IClickZoneRepository
    {
        Task AddClickZoneAsync(ClickZone clickZone);
    }
}
