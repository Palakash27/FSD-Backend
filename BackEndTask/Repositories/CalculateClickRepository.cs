using BackEndTask.Data;
using BackEndTask.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Repositories
{
    public class CalculateClickRepository: ICalculateClickRepository
    {
        private readonly ExcelProcessorDbContext _context;

        public CalculateClickRepository(ExcelProcessorDbContext context)
        {
            _context = context;
        }

        public List<ZoneClickCountDTO> GetClickCountsAsync()
        {
            try
            {
                var query = @"
                    WITH ZoneBounds AS (
                        SELECT 
                            z.id AS ZoneId,
                            z.ZoneName AS ZoneName,
                            CAST(PARSENAME(REPLACE(z.ZoneCord, ',', '.'), 4) AS FLOAT) AS x1,
                            CAST(PARSENAME(REPLACE(z.ZoneCord, ',', '.'), 3) AS FLOAT) AS y1,
                            CAST(PARSENAME(REPLACE(z.ZoneCord, ',', '.'), 2) AS FLOAT) AS x2,
                            CAST(PARSENAME(REPLACE(z.ZoneCord, ',', '.'), 1) AS FLOAT) AS y2 
                        FROM Zone z
                    ),
                    ClickCounts AS (
                        SELECT 
                            zb.ZoneId,
                            COUNT(cz.id) AS ClickCount
                        FROM ClickZone cz
                        JOIN ZoneBounds zb
                            ON cz.XCord >= zb.x1 AND cz.XCord <= zb.x2
                            AND cz.YCord >= zb.y1 AND cz.YCord <= zb.y2
                        GROUP BY zb.ZoneId
                    )
                    SELECT 
                        z.ZoneName AS ZoneName,
                        cc.ClickCount
                    FROM ClickCounts cc
                    JOIN Zone z ON z.id = cc.ZoneId;";

                var zoneClickData = _context.ZoneClickCountDTO
                    .FromSqlRaw(query)
                    .ToList();

                return zoneClickData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CalculateClickRepository: GetClickCountsAsync -> " + ex.Message);
            }
        }
    }
}
