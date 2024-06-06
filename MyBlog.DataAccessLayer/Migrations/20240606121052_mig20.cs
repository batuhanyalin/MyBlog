using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturePostsId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeaturePost",
                columns: table => new
                {
                    FeaturePostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturePost", x => x.FeaturePostId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_FeaturePost_FeaturePostsId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "FeaturePost");

            migrationBuilder.DropIndex(
                name: "IX_Articles_FeaturePostsId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FeaturePostsId",
                table: "Articles");
        }
    }
}
