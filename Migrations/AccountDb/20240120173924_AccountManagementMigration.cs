using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uHubAPI.Migrations.AccountDb
{
    /// <inheritdoc />
    public partial class AccountManagementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
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
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerAddresses",
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
                    table.PrimaryKey("PK_SellerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerAddresses_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPoints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPoints = table.Column<long>(type: "bigint", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPoints_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointDetails",
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
                    table.PrimaryKey("PK_PointDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointDetails_UserPoints_UserPointId",
                        column: x => x.UserPointId,
                        principalTable: "UserPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_MarketplaceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketplaceItem_SellerAddresses_SellerAddressId",
                        column: x => x.SellerAddressId,
                        principalTable: "SellerAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketplaceItem_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceItemImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketplaceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceItemImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceItemImage_MarketplaceItem_MarketplaceItemId",
                        column: x => x.MarketplaceItemId,
                        principalTable: "MarketplaceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    MarketplaceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistories_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHistories_MarketplaceItem_MarketplaceItemId",
                        column: x => x.MarketplaceItemId,
                        principalTable: "MarketplaceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItem_CategoryId",
                table: "MarketplaceItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItem_SellerAddressId",
                table: "MarketplaceItem",
                column: "SellerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItem_WishlistId",
                table: "MarketplaceItem",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItemImage_MarketplaceItemId",
                table: "MarketplaceItemImage",
                column: "MarketplaceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_AppUserId",
                table: "OrderHistories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_MarketplaceItemId",
                table: "OrderHistories",
                column: "MarketplaceItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointDetails_UserPointId",
                table: "PointDetails",
                column: "UserPointId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerAddresses_AppUserId",
                table: "SellerAddresses",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_AppUserId",
                table: "UserPoints",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AppUserId",
                table: "UserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_AppUserId",
                table: "Wishlists",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketplaceItemImage");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropTable(
                name: "PointDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MarketplaceItem");

            migrationBuilder.DropTable(
                name: "UserPoints");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SellerAddresses");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
