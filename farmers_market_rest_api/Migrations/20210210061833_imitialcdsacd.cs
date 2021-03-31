using Microsoft.EntityFrameworkCore.Migrations;

namespace farmers_market_rest_api.Migrations
{
    public partial class imitialcdsacd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_FarmerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FarmerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FarmerPhoneNo",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DivisionName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FarmerId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketCode",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnionOrWardId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionOrWardName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpozilaId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpozilaName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DistrictId",
                table: "Products",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DivisionId",
                table: "Products",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FarmerId",
                table: "Products",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarketId",
                table: "Products",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnionOrWardId",
                table: "Products",
                column: "UnionOrWardId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpozilaId",
                table: "Products",
                column: "UpozilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Districts_DistrictId",
                table: "Products",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Divisions_DivisionId",
                table: "Products",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_FarmerId",
                table: "Products",
                column: "FarmerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Markets_MarketId",
                table: "Products",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnionOrWards_UnionOrWardId",
                table: "Products",
                column: "UnionOrWardId",
                principalTable: "UnionOrWards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Upozillas_UpozilaId",
                table: "Products",
                column: "UpozilaId",
                principalTable: "Upozillas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Districts_DistrictId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Divisions_DivisionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_FarmerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Markets_MarketId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnionOrWards_UnionOrWardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Upozillas_UpozilaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DistrictId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DivisionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FarmerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnionOrWardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UpozilaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DivisionName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarketCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarketName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnionOrWardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnionOrWardName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpozilaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpozilaName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "FarmerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FarmerPhoneNo",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FarmerId",
                table: "Orders",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_FarmerId",
                table: "Orders",
                column: "FarmerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
