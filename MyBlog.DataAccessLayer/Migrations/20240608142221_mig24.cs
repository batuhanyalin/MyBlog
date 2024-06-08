using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_FeaturePosts_FeaturePostId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_FeaturePostId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FeaturePostId",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturePostId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_FeaturePostId",
                table: "Articles",
                column: "FeaturePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_FeaturePosts_FeaturePostId",
                table: "Articles",
                column: "FeaturePostId",
                principalTable: "FeaturePosts",
                principalColumn: "FeaturePostId");
        }
    }
}
