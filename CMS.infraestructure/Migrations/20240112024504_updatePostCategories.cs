using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class updatePostCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_PostId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PostId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryPost",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPost", x => new { x.CategoriesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_CategoryPost_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDrEnL5x8KgM9Y3BftT63pqelG2bHC3dtSqNLKs7PiQdjrwcy/gV+WsIS8bSEPSwAA==");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_PostsId",
                table: "CategoryPost",
                column: "PostsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPost");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGdZJ96+tzfhnoq4BV41DcqJbWM95tzl/FkNppVlALrj9k52wuLzttG5pl216pnpbw==");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PostId",
                table: "Categories",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_PostId",
                table: "Categories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
