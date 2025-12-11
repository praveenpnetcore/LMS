using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "ReaderRecords",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderRecords", x => x.ReaderId);
                    table.ForeignKey(
                        name: "FK_ReaderRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "ISBN", "IsAvailable", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Mark J. Price", "978-1803237807", true, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern C# Programming Essentials" },
                    { 2, "Jason Taylor", "978-0134494166", true, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Architecture in .NET" },
                    { 3, "Adam Freeman", "978-1484279567", true, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API Guide" },
                    { 4, "Grant Fritchey", "978-1484259620", true, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server Query Performance Tuning" },
                    { 5, "Jon P Smith", "978-1617294563", true, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework Core in Action" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReaderRecords_BookId",
                table: "ReaderRecords",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReaderRecords");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
