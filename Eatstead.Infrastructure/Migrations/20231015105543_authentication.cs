using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eatstead.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class authentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cafeterias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Cafeterias",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cafeterias");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Cafeterias");
        }
    }
}
