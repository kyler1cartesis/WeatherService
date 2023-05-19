using System.Data;
using Ganss.Excel;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using WeatherService_DynamicSun.Models;

namespace WeatherService.Data;

public class WeatherServiceContext : DbContext
{
    public DbSet<WeatherConditions> WeatherConditions { get; set; } = default!;
    
    public WeatherServiceContext (DbContextOptions<WeatherServiceContext> options)
        : base(options) {
    }
        
    public IOrderedQueryable<WeatherConditions> GetData (Months month, int? year) {
        IQueryable<WeatherConditions> query = WeatherConditions.AsQueryable();
        if (year is not null)
             query = query.Where(x => x.Date.Year == year);
        if (month != Months.все)
            query = query.Where(x => x.Date.Month == (int) month);
        return query.OrderBy(x => x.Date);
    }
    public void SendDataToDb (IFormFile[] files) {
        foreach (var file in files) {
            IWorkbook workbook = WorkbookFactory.Create(file.OpenReadStream());
            int NumberOfSheets = workbook.NumberOfSheets;
            if (NumberOfSheets == 0) throw new ArgumentException("No sheets in workbook!");
            ExcelMapper mapper = new(workbook) { HeaderRow = false, MinRowNumber = 4, TrackObjects = false };
            mapper.AddMapping<WeatherConditions>(1, x => x.Date)
                .SetPropertyUsing(v => {
                    return v switch {
                        null => null,
                        _ => DateTime.Parse((string) v)
                    };
                });
            mapper.AddMapping<WeatherConditions>(2, x => x.Time)
                .SetPropertyUsing(v => {
                    return v switch {
                        null => null,
                        _ => TimeSpan.Parse((string) v)
                    };
                });
            for (int index = 0; index < NumberOfSheets; index++) {
                WeatherConditions.AddRange(
                    mapper.Fetch<WeatherConditions>(index));
            }
            SaveChanges();
        }
    }
}
