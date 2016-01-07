using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TheWorld.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Trip",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Trip",
                newName: "Username");
        }
    }
}
