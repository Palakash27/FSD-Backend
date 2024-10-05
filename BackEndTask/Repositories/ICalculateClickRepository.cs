using BackEndTask.DTOs;

namespace BackEndTask.Repositories
{
    public interface ICalculateClickRepository
    {
        List<ZoneClickCountDTO> GetClickCountsAsync();
    }
}
