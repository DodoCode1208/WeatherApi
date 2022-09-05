using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentWeather",
                columns: table => new
                {
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CaculationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeather", x => x.CurrentWeatherId);
                });

            migrationBuilder.CreateTable(
                name: "CloudinessInfo",
                columns: table => new
                {
                    CloudinessInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CloudinessPercentageValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudinessInfo", x => x.CloudinessInfoId);
                    table.ForeignKey(
                        name: "FK_CloudinessInfo_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RainVolumeInfo",
                columns: table => new
                {
                    RainVolumeInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RainInAnHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RainIn3HourPeriod = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainVolumeInfo", x => x.RainVolumeInfoId);
                    table.ForeignKey(
                        name: "FK_RainVolumeInfo_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnowVolumeInfo",
                columns: table => new
                {
                    SnowVolumeInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnowInAnHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnowIn3HourPeriod = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnowVolumeInfo", x => x.SnowVolumeInfoId);
                    table.ForeignKey(
                        name: "FK_SnowVolumeInfo_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherIconId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weather_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId");
                });

            migrationBuilder.CreateTable(
                name: "WeatherMainInfo",
                columns: table => new
                {
                    WeatherMainInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureInfo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperatureFeelsLikeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperatureMinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperatureMaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AtmosphericPressureSeaLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AtmosphericPressureGroundLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherMainInfo", x => x.WeatherMainInfoId);
                    table.ForeignKey(
                        name: "FK_WeatherMainInfo_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WindParameters",
                columns: table => new
                {
                    WindParamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WindDirection = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WindGust = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentWeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindParameters", x => x.WindParamId);
                    table.ForeignKey(
                        name: "FK_WindParameters_CurrentWeather_CurrentWeatherId",
                        column: x => x.CurrentWeatherId,
                        principalTable: "CurrentWeather",
                        principalColumn: "CurrentWeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloudinessInfo_CurrentWeatherId",
                table: "CloudinessInfo",
                column: "CurrentWeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RainVolumeInfo_CurrentWeatherId",
                table: "RainVolumeInfo",
                column: "CurrentWeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SnowVolumeInfo_CurrentWeatherId",
                table: "SnowVolumeInfo",
                column: "CurrentWeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CurrentWeatherId",
                table: "Weather",
                column: "CurrentWeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherMainInfo_CurrentWeatherId",
                table: "WeatherMainInfo",
                column: "CurrentWeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WindParameters_CurrentWeatherId",
                table: "WindParameters",
                column: "CurrentWeatherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CloudinessInfo");

            migrationBuilder.DropTable(
                name: "RainVolumeInfo");

            migrationBuilder.DropTable(
                name: "SnowVolumeInfo");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherMainInfo");

            migrationBuilder.DropTable(
                name: "WindParameters");

            migrationBuilder.DropTable(
                name: "CurrentWeather");
        }
    }
}
