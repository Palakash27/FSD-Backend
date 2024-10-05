using BackEndTask.Data.Entities;
using BackEndTask.Repositories;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace BackEndTask.Services
{
    public class ExcelProcessingService
    {
        private readonly IClickZoneRepository _clickZoneRepository;
        private readonly IZoneRepository _zoneRepository;

        public ExcelProcessingService(IClickZoneRepository clickZoneRepository, IZoneRepository zoneRepository)
        {
            _clickZoneRepository = clickZoneRepository;
            _zoneRepository = zoneRepository;
        }

        public async Task ProcessExcelFileAsync(ExcelPackage package)
        {
            var worksheet = package.Workbook.Worksheets[0];
            int totalRows = worksheet.Dimension.End.Row;

            // Process ClickZone Table (Columns A, B, C)
            for (int row = 2; row <= totalRows; row++)
            {
                var clickZoneIdCell = worksheet.Cells[row, 1].Text;
                if (!string.IsNullOrWhiteSpace(clickZoneIdCell) && int.TryParse(clickZoneIdCell, out var clickZoneId))
                {
                    var clickZone = new ClickZone
                    {
                        Id = clickZoneId,
                        XCord = double.Parse(worksheet.Cells[row, 2].Text),
                        YCord = double.Parse(worksheet.Cells[row, 3].Text)
                    };
                    await _clickZoneRepository.AddClickZoneAsync(clickZone);
                }
            }

            // Process Zone Table (Columns F, G, h)
            for (int row = 2; row <= totalRows; row++)
            {
                var zoneIdCell = worksheet.Cells[row, 6].Text;
                if (!string.IsNullOrWhiteSpace(zoneIdCell) && int.TryParse(zoneIdCell, out var zoneId))
                {
                    var zone = new Zone
                    {
                        Id = zoneId,
                        ZoneName = worksheet.Cells[row, 7].Text,
                        ZoneCord = worksheet.Cells[row, 8].Text
                    };
                    await _zoneRepository.AddZoneAsync(zone);
                }
            }
        }
    }
}