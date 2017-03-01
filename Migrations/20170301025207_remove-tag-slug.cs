using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace MindHypertrophy.Migrations
{
    public partial class removetagslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_CardTag_Card_CardId", table: "CardTag");
            migrationBuilder.DropForeignKey(name: "FK_CardTag_Tag_TagId", table: "CardTag");
            migrationBuilder.DropColumn(name: "Slug", table: "Tag");
            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Card_CardId",
                table: "CardTag",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Tag_TagId",
                table: "CardTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_CardTag_Card_CardId", table: "CardTag");
            migrationBuilder.DropForeignKey(name: "FK_CardTag_Tag_TagId", table: "CardTag");
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Tag",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Card_CardId",
                table: "CardTag",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Tag_TagId",
                table: "CardTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
