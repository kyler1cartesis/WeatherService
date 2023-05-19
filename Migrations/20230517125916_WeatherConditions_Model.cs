using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherService_DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class WeatherConditions_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    TemperatureAir = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    RelativeHumidity = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DewPoint = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    AtmosphericPressure = table.Column<short>(type: "smallint", nullable: false),
                    WindDirection = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WindSpeed = table.Column<byte>(type: "tinyint", nullable: true),
                    CloudCover = table.Column<byte>(type: "tinyint", nullable: true),
                    LowerCloudLimit = table.Column<short>(type: "smallint", nullable: true),
                    HorizontalVisibility = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WeatherPhenomena = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherConditions");
        }
    }
}
