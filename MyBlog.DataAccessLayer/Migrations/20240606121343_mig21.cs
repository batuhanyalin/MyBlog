using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_FeaturePost_FeaturePostsId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_FeaturePostsId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FeaturePostsId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "FeaturePost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeaturePost_ArticleId",
                table: "FeaturePost",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturePost_Articles_ArticleId",
                table: "FeaturePost",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturePost_Articles_ArticleId",
                table: "FeaturePost");

            migrationBuilder.DropIndex(
                name: "IX_FeaturePost_ArticleId",
                table: "FeaturePost");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "FeaturePost");

            migrationBuilder.AddColumn<int>(
                name: "FeaturePostsId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_FeaturePostsId",
                table: "Articles",
                column: "FeaturePostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_FeaturePost_FeaturePostsId",
                table: "Articles",
                column: "FeaturePostsId",
                principalTable: "FeaturePost",
                principalColumn: "FeaturePostId");
        }
    }
}
