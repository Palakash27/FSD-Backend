using BackEndTask.Repositories;
using BackEndTask.DTOs;

namespace BackEndTask.Services
{
    public class CalculateClickService
    {
        private readonly ICalculateClickRepository _calculateClickRepository;

        public CalculateClickService(ICalculateClickRepository calculateClickRepository)
        {
            _calculateClickRepository = calculateClickRepository;
        }

        public List<ZoneClickCountDTO> GetClickCountsAsync()
        {
            return _calculateClickRepository.GetClickCountsAsync();
        }
    }
}
