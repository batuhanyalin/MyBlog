using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturePost_Articles_ArticleId",
                table: "FeaturePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeaturePost",
                table: "FeaturePost");

            migrationBuilder.RenameTable(
                name: "FeaturePost",
                newName: "FeaturePosts");

            migrationBuilder.RenameIndex(
                name: "IX_FeaturePost_ArticleId",
                table: "FeaturePosts",
                newName: "IX_FeaturePosts_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeaturePosts",
                table: "FeaturePosts",
                column: "FeaturePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturePosts_Articles_ArticleId",
                table: "FeaturePosts",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturePosts_Articles_ArticleId",
                table: "FeaturePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeaturePosts",
                table: "FeaturePosts");

            migrationBuilder.RenameTable(
                name: "FeaturePosts",
                newName: "FeaturePost");

            migrationBuilder.RenameIndex(
                name: "IX_FeaturePosts_ArticleId",
                table: "FeaturePost",
                newName: "IX_FeaturePost_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeaturePost",
                table: "FeaturePost",
                column: "FeaturePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturePost_Articles_ArticleId",
                table: "FeaturePost",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");
        }
    }
}
