using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherService.Data;
using WeatherService_DynamicSun.Models;
using X.PagedList;

namespace WeatherService_DynamicSun.Controllers;

public class WeatherConditionsController : Controller
{
    private readonly WeatherServiceContext _context;
    private static readonly ViewModel viewModel = new();

    public WeatherConditionsController (WeatherServiceContext context) => _context = context;

    // GET: WeatherConditions
    public async Task<IActionResult> Index (Months? SelectedMonth, int? SelectedYear, int? PageIndex) {
        if (_context.WeatherConditions is null)
            return Problem("Entity set 'WeatherServiceContext.WeatherConditions'  is null.");

        if (SelectedMonth is not null) viewModel.SelectedMonth = (Months) SelectedMonth;
        if (SelectedYear is not null) viewModel.SelectedYear = (int) SelectedYear;
        viewModel.CurrentPageData = await _context.GetData(viewModel.SelectedMonth, viewModel.SelectedYear).ToPagedListAsync(PageIndex ?? 1, viewModel.PageSize);
        return View(viewModel);
    }

    // GET: WeatherConditions/Details/5
    public async Task<IActionResult> Details (int? id) {
        if (id == null || _context.WeatherConditions == null) {
            return NotFound();
        }

        var weatherConditions = await _context.WeatherConditions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (weatherConditions == null) {
            return NotFound();
        }

        return View(weatherConditions);
    }

    // GET: WeatherConditions/Create
    public IActionResult Create () => View();

    public IActionResult UploadTable () => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UploadTable (params IFormFile[] files) {
        if (files == null || files.Length <= 0)
            return NotFound("Table hasn't been provided!");
        try {
            _context.SendDataToDb(files);
        }
        catch (Exception exc) {
            ViewBag.ErrorType = exc.GetType().FullName;
            ViewBag.Error = exc.Message;
            return View(); }
        return RedirectToAction(nameof(Index));
    }

    // POST: WeatherConditions/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create ([Bind("Id,Date,Time,TemperatureAir,RelativeHumidity,DewPoint,AtmosphericPresure,WindDirection,WindSpeed,CloudCover,LowerCloudLimit,HorizontalVisibility,WeatherPhenomena")] WeatherConditions weatherConditions) {
        if (ModelState.IsValid) {
            _context.Add(weatherConditions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(weatherConditions);
    }

    // GET: WeatherConditions/Edit/5
    public async Task<IActionResult> Edit (int? id) {
        if (id == null || _context.WeatherConditions == null) {
            return NotFound();
        }

        var weatherConditions = await _context.WeatherConditions.FindAsync(id);
        if (weatherConditions == null) {
            return NotFound();
        }
        return View(weatherConditions);
    }

    // POST: WeatherConditions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit (int id, [Bind("Id,Date,Time,TemperatureAir,RelativeHumidity,DewPoint,AtmosphericPresure,WindDirection,WindSpeed,CloudCover,LowerCloudLimit,HorizontalVisibility,WeatherPhenomena")] WeatherConditions weatherConditions) {
        if (id != weatherConditions.Id) {
            return NotFound();
        }

        if (ModelState.IsValid) {
            try {
                _context.Update(weatherConditions);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!WeatherConditionsExists(weatherConditions.Id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(weatherConditions);
    }

    // GET: WeatherConditions/Delete/5
    public async Task<IActionResult> Delete (int? id) {
        if (id == null || _context.WeatherConditions == null) {
            return NotFound();
        }

        var weatherConditions = await _context.WeatherConditions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (weatherConditions == null) {
            return NotFound();
        }

        return View(weatherConditions);
    }

    // POST: WeatherConditions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed (int id) {
        if (_context.WeatherConditions == null) {
            return Problem("Entity set 'WeatherServiceContext.WeatherConditions'  is null.");
        }
        var weatherConditions = await _context.WeatherConditions.FindAsync(id);
        if (weatherConditions != null) {
            _context.WeatherConditions.Remove(weatherConditions);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WeatherConditionsExists (int id) => (_context.WeatherConditions?.Any(e => e.Id == id)).GetValueOrDefault();
}
