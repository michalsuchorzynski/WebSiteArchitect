using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebSiteArchitect.AdminAPI.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Page_SiteId",
                table: "Page",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_SiteId",
                table: "Menu",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Site_SiteId",
                table: "Menu",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Site_SiteId",
                table: "Page",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Site_SiteId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Page_Site_SiteId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_SiteId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Menu_SiteId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Menu");
        }
    }
}
