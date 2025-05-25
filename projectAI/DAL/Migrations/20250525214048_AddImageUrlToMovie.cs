using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeGroup",
                columns: table => new
                {
                    AgeCode = table.Column<int>(type: "int", nullable: false),
                    AgeDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AgeGroup__5B97C6189522A6E4", x => x.AgeCode);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryCode = table.Column<int>(type: "int", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__371BA954161E6948", x => x.CategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "EmailTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DateClicked = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailTra__3214EC07BD40BFD7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__3214EC0769967814", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    CategoryCode = table.Column<int>(type: "int", nullable: true),
                    AgeCode = table.Column<int>(type: "int", nullable: true),
                    ThereIsWoman = table.Column<bool>(type: "bit", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    AmountOfViews = table.Column<int>(type: "int", nullable: true),
                    FilmProductionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ExtraViewerPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ExtraViewPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movies__3214EC07627911D3", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Movies__AgeCode__16CE6296",
                        column: x => x.AgeCode,
                        principalTable: "AgeGroup",
                        principalColumn: "AgeCode");
                    table.ForeignKey(
                        name: "FK__Movies__Category__15DA3E5D",
                        column: x => x.CategoryCode,
                        principalTable: "Category",
                        principalColumn: "CategoryCode");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07AFEFEC21", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Users__RoleId__0E391C95",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    AgeGroup = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__1788CC4CA2F6AA3C", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Customers__AgeGr__12FDD1B2",
                        column: x => x.AgeGroup,
                        principalTable: "AgeGroup",
                        principalColumn: "AgeCode");
                    table.ForeignKey(
                        name: "FK__Customers__UserI__1209AD79",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailLinks",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    UniqueToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    EmailType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ViewLimit = table.Column<int>(type: "int", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailLin__2D12215556B5F683", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK__EmailLink__Movie__29E1370A",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__EmailLink__UserI__28ED12D1",
                        column: x => x.UserID,
                        principalTable: "Customers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C38F300988E32713", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK__Orders__IdCustom__1C873BEC",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "EmailLinkClicks",
                columns: table => new
                {
                    ClickID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkID = table.Column<int>(type: "int", nullable: false),
                    ClickDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Converted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailLin__F8E74E2EAC1007D4", x => x.ClickID);
                    table.ForeignKey(
                        name: "FK__EmailLink__LinkI__2EA5EC27",
                        column: x => x.LinkID,
                        principalTable: "EmailLinks",
                        principalColumn: "LinkID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ViewerCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__3214EC070C2FAC08", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderItem__Movie__22401542",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderItem__Order__214BF109",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AgeGroup",
                table: "Customers",
                column: "AgeGroup");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLinkClicks_LinkID",
                table: "EmailLinkClicks",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLinks_MovieID",
                table: "EmailLinks",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLinks_UniqueToken",
                table: "EmailLinks",
                column: "UniqueToken");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLinks_UserID",
                table: "EmailLinks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__EmailLin__64D6B76BBD003BDE",
                table: "EmailLinks",
                column: "UniqueToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AgeCode",
                table: "Movies",
                column: "AgeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryCode",
                table: "Movies",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534957378DF",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailLinkClicks");

            migrationBuilder.DropTable(
                name: "EmailTracking");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "EmailLinks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "AgeGroup");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
