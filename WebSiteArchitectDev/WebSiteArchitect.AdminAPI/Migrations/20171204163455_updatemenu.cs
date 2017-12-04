using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebSiteArchitect.AdminAPI.Migrations
{
    public partial class updatemenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Controls",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XamlPage",
                table: "Menu",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controls",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "XamlPage",
                table: "Menu");
        }
    }
}
