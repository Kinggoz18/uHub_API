using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uHubAPI.Migrations.MarketplaceDb
{
    /// <inheritdoc />
    public partial class MarketplaceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    ReportCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerAddress_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPoint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPoints = table.Column<long>(type: "bigint", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPoint_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPointId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointDetail_UserPoint_UserPointId",
                        column: x => x.UserPointId,
                        principalTable: "UserPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DefaultImageKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerAddressId = table.Column<long>(type: "bigint", nullable: false),
                    WishlistId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketplaceItems_SellerAddress_SellerAddressId",
                        column: x => x.SellerAddressId,
                        principalTable: "SellerAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketplaceItems_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceItemImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketplaceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceItemImages_MarketplaceItems_MarketplaceItemId",
                        column: x => x.MarketplaceItemId,
                        principalTable: "MarketplaceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    MarketplaceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistory_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHistory_MarketplaceItems_MarketplaceItemId",
                        column: x => x.MarketplaceItemId,
                        principalTable: "MarketplaceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItemImages_MarketplaceItemId",
                table: "MarketplaceItemImages",
                column: "MarketplaceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_CategoryId",
                table: "MarketplaceItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_SellerAddressId",
                table: "MarketplaceItems",
                column: "SellerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_WishlistId",
                table: "MarketplaceItems",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_AppUserId",
                table: "OrderHistory",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_MarketplaceItemId",
                table: "OrderHistory",
                column: "MarketplaceItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointDetail_UserPointId",
                table: "PointDetail",
                column: "UserPointId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerAddress_AppUserId",
                table: "SellerAddress",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPoint_AppUserId",
                table: "UserPoint",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_AppUserId",
                table: "UserRole",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_AppUserId",
                table: "Wishlist",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketplaceItemImages");

            migrationBuilder.DropTable(
                name: "OrderHistory");

            migrationBuilder.DropTable(
                name: "PointDetail");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "MarketplaceItems");

            migrationBuilder.DropTable(
                name: "UserPoint");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SellerAddress");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
