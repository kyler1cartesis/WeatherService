using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace WeatherService_DynamicSun.Models;

public class ViewModel {
    internal IPagedList<WeatherConditions>? CurrentPageData {
        get => currentPageData;
        set { currentPageData = value;
              FirstItem = currentPageData?.Count > 0 ? currentPageData[0] : null; }
    }
    public WeatherConditions? FirstItem { get; private set; }
    internal Months SelectedMonth = Months.все;
    internal int? SelectedYear {
        get => selectedYear;
        set => selectedYear = value != 0 ? value : null;
    }
    internal int PageSize = 100;

    public static readonly SelectList Years;
    static ViewModel () {
        Years = new(Enumerable.Range(2000, 24).Append(0).Reverse());
        //var firstItem = Years.First();
        //firstItem = new SelectListItem("все", "0");
    }

    private IPagedList<WeatherConditions>? currentPageData;
    private int? selectedYear;
}
public enum Months : byte { все, январь = 1, февраль, март, апрель, май, июнь, июль, август, сентябрь, октябрь, ноябрь, декабрь };