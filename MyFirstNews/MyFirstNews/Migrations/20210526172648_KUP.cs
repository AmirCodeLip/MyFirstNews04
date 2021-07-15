using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstNews.Migrations
{
    public partial class KUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsImages_Newses_NewsId",
                table: "NewsImages");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "NewsImages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsImages_Newses_NewsId",
                table: "NewsImages",
                column: "NewsId",
                principalTable: "Newses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsImages_Newses_NewsId",
                table: "NewsImages");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "NewsImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsImages_Newses_NewsId",
                table: "NewsImages",
                column: "NewsId",
                principalTable: "Newses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
