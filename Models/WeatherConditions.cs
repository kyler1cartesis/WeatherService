using Ganss.Excel;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.ComponentModel.DataAnnotations;

namespace WeatherService_DynamicSun.Models;

public record WeatherConditions (
    [property: Ignore] int Id,
    [property: Column(1)][property: DataType(DataType.Date)] DateTime Date,
    [property: Column(2)][property: DataType(DataType.Time)] TimeSpan Time,
    [property: Column(3)][property: Precision(4, 2)] decimal TemperatureAir,
    [property: Column(4)][property: Precision(5, 2)] decimal RelativeHumidity,
    [property: Column(5)][property: Precision(4, 2)] decimal DewPoint,
    [property: Column(6)] short AtmosphericPressure,
    [property: Column(7)][property: MaxLength(10)] string? WindDirection,
    [property: Column(8)] byte? WindSpeed,
    [property: Column(9)] byte? CloudCover,
    [property: Column(10)] short? LowerCloudLimit,
    [property: Column(11)] string? HorizontalVisibility,
    [property: Column(12)][property: MaxLength(60)] string? WeatherPhenomena);
