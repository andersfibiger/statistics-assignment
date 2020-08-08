using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Statistics.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyStatistics",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfExperiences = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStatistics", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DailyStatistics",
                columns: new[] { "Id", "NumberOfExperiences", "TimeStamp" },
                values: new object[,]
                {
                    { 1L, 380, new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 395, new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 407, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 415, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyStatistics");
        }
    }
}
