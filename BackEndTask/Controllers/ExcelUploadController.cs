

using BackEndTask.Services;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using BackEndTask.DTOs;

namespace BackEndTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelUploadController : ControllerBase
    {
        private readonly ExcelProcessingService _excelProcessingService;

        public ExcelUploadController(ExcelProcessingService excelProcessingService)
        {
            _excelProcessingService = excelProcessingService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcelFile(IFormFile file)
        {
            ResponseInfo<string> response = new ResponseInfo<string>();
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using var package = new ExcelPackage(stream);
                    await _excelProcessingService.ProcessExcelFileAsync(package);
                }
                response.ResponseStatus = true;
                response.ResponseMessage = "Successfully processed excel file and data saved to the database.";
            }
            catch (Exception ex)
            {
                response.ResponseStatus = false;
                response.ResponseMessage = "Unexpected error in UploadExcelFile: " + ex.Message;
            }
            return Ok(response);
        }
    }
}
