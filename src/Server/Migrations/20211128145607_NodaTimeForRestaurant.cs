using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace LtuLunch.Server.Migrations
{
    public partial class NodaTimeForRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalTime>(
                name: "OpensWhen",
                table: "Resturants",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpensWhen",
                table: "Resturants",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(LocalTime),
                oldType: "time");
        }
    }
}
