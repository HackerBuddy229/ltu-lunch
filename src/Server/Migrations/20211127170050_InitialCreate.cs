using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LtuLunch.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OpensWhen = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    OpenFor = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lunches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ResturantId = table.Column<string>(type: "text", nullable: false),
                    When = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ResturantId1 = table.Column<string>(type: "text", nullable: true),
                    ResturantId2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lunches_Resturants_ResturantId",
                        column: x => x.ResturantId,
                        principalTable: "Resturants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lunches_Resturants_ResturantId1",
                        column: x => x.ResturantId1,
                        principalTable: "Resturants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lunches_Resturants_ResturantId2",
                        column: x => x.ResturantId2,
                        principalTable: "Resturants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lunches_ResturantId",
                table: "Lunches",
                column: "ResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_Lunches_ResturantId1",
                table: "Lunches",
                column: "ResturantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lunches_ResturantId2",
                table: "Lunches",
                column: "ResturantId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropTable(
                name: "Resturants");
        }
    }
}
