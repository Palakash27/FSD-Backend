using Azure;
using BackEndTask.DTOs;
using BackEndTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateClickController : ControllerBase
    {
        private readonly CalculateClickService _calculateClickService;

        public CalculateClickController(CalculateClickService calculateClickZoneService)
        {
            _calculateClickService = calculateClickZoneService;
        }

        [HttpGet("count")]
        public IActionResult GetZoneClickCounts()
        {
            ResponseInfo<List<ZoneClickCountDTO>> response = new ResponseInfo<List<ZoneClickCountDTO>>();
            try
            { 
                var result = _calculateClickService.GetClickCountsAsync();
                if (result == null || result.Count == 0)
                {
                    response.ResponseStatus = false;
                    response.ResponseMessage = "No clicks found for any zones.";
                    return NotFound(response);
                }
                response.ResponseStatus = true;
                response.ResponseMessage = "Successfully retrieved the Zone Click Counts.";
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = false;
                response.ResponseMessage = "Unexpected error in GetZoneClickCounts: " + ex.Message;
            }
            return Ok(response);
        }
    }
}
