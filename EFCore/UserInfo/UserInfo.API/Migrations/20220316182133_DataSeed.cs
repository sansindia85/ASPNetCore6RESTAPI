using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserInfo.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Passionate backend guy.", "Sandeep Kandula" },
                    { 2, "Passionate backend guy.", "Kiran" },
                    { 3, "Passionate testing guy.", "Sanjeev" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "The latest .Net", "DotNet6", 1 },
                    { 2, "The latest Android", "Andorid12", 1 },
                    { 3, "Reusable web components.", "StencilJS", 2 },
                    { 4, "TypeScript is a strongly typed programming language that builds on JavaScript.", "TypeScript", 2 },
                    { 5, "Designed to load test functional behavior and measure performance.", "JMeter", 3 },
                    { 6, "Open source record and playback test automation for the web.", "Selenium IDE", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
