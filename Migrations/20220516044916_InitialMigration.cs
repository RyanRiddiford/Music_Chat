using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_chat.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => new { x.Email, x.AccountId });
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AuthorUsername = table.Column<string>(type: "text", nullable: false),
                    AuthorProfileImage = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ImageUrl", "Username" },
                values: new object[,]
                {
                    { new Guid("5dbdef4c-271b-4515-8c5f-f56a18def458"), "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1" },
                    { new Guid("b885d1e4-0d07-44c0-b3bb-b36e85a6ab2c"), "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user2.JPG", "user2" },
                    { new Guid("da37ddc1-2f8e-44a6-a499-44227e2c48d6"), "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user3.JPG", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "AccountId", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("5dbdef4c-271b-4515-8c5f-f56a18def458"), "user1@email.com", "user1" },
                    { new Guid("b885d1e4-0d07-44c0-b3bb-b36e85a6ab2c"), "user2@email.com", "user2" },
                    { new Guid("da37ddc1-2f8e-44a6-a499-44227e2c48d6"), "user3@email.com", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorProfileImage", "AuthorUsername", "Content", "date", "timestamp" },
                values: new object[,]
                {
                    { "1", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 1", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 10, 0, DateTimeKind.Utc) },
                    { "10", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 10", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 19, 0, DateTimeKind.Utc) },
                    { "11", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 11", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 10, 0, DateTimeKind.Utc) },
                    { "12", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 12", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 11, 0, DateTimeKind.Utc) },
                    { "13", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 13", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 12, 0, DateTimeKind.Utc) },
                    { "14", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 14", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 13, 0, DateTimeKind.Utc) },
                    { "15", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 15", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 14, 0, DateTimeKind.Utc) },
                    { "16", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 16", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 15, 0, DateTimeKind.Utc) },
                    { "17", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 17", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 16, 0, DateTimeKind.Utc) },
                    { "18", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 18", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 17, 0, DateTimeKind.Utc) },
                    { "19", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 19", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 18, 0, DateTimeKind.Utc) },
                    { "2", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 2", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 11, 0, DateTimeKind.Utc) },
                    { "20", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 20", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 19, 0, DateTimeKind.Utc) },
                    { "21", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 21", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 20, 0, DateTimeKind.Utc) },
                    { "22", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 22", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 21, 0, DateTimeKind.Utc) },
                    { "23", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 23", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 22, 0, DateTimeKind.Utc) },
                    { "24", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 24", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 23, 0, DateTimeKind.Utc) },
                    { "25", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 25", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 2, 2, 12, 24, 0, DateTimeKind.Utc) },
                    { "26", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 26", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 10, 0, DateTimeKind.Utc) },
                    { "27", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 27", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 11, 0, DateTimeKind.Utc) },
                    { "28", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 28", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 12, 0, DateTimeKind.Utc) },
                    { "29", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 29", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 13, 0, DateTimeKind.Utc) },
                    { "3", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 3", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 12, 0, DateTimeKind.Utc) },
                    { "30", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 30", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 14, 0, DateTimeKind.Utc) },
                    { "31", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 31", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 15, 0, DateTimeKind.Utc) },
                    { "32", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 32", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 16, 0, DateTimeKind.Utc) },
                    { "33", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 33", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 17, 0, DateTimeKind.Utc) },
                    { "34", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 34", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 18, 0, DateTimeKind.Utc) },
                    { "35", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 35", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 19, 0, DateTimeKind.Utc) },
                    { "36", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 36", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 20, 0, DateTimeKind.Utc) },
                    { "37", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 37", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 21, 0, DateTimeKind.Utc) },
                    { "38", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 38", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 22, 0, DateTimeKind.Utc) },
                    { "39", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 39", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 23, 0, DateTimeKind.Utc) },
                    { "4", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 4", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 13, 0, DateTimeKind.Utc) },
                    { "40", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 40", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 24, 0, DateTimeKind.Utc) },
                    { "41", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 41", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 25, 0, DateTimeKind.Utc) },
                    { "42", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 42", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 26, 0, DateTimeKind.Utc) },
                    { "43", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 43", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 3, 2, 12, 27, 0, DateTimeKind.Utc) },
                    { "44", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 44", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 10, 0, DateTimeKind.Utc) },
                    { "45", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 45", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 11, 0, DateTimeKind.Utc) },
                    { "46", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 46", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 12, 0, DateTimeKind.Utc) },
                    { "47", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 47", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 13, 0, DateTimeKind.Utc) },
                    { "48", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 48", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 14, 0, DateTimeKind.Utc) },
                    { "49", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 49", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 15, 0, DateTimeKind.Utc) },
                    { "5", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 5", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 14, 0, DateTimeKind.Utc) },
                    { "50", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 50", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 16, 0, DateTimeKind.Utc) },
                    { "51", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 51", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 17, 0, DateTimeKind.Utc) },
                    { "52", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 52", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 18, 0, DateTimeKind.Utc) },
                    { "53", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 53", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 19, 0, DateTimeKind.Utc) },
                    { "54", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 54", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 20, 0, DateTimeKind.Utc) },
                    { "55", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 55", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 21, 0, DateTimeKind.Utc) },
                    { "56", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 56", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 22, 0, DateTimeKind.Utc) },
                    { "57", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 57", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 23, 0, DateTimeKind.Utc) },
                    { "58", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 58", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 24, 0, DateTimeKind.Utc) },
                    { "59", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 59", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 25, 0, DateTimeKind.Utc) },
                    { "6", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 6", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 15, 0, DateTimeKind.Utc) },
                    { "60", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 60", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 26, 0, DateTimeKind.Utc) },
                    { "61", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 61", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 27, 0, DateTimeKind.Utc) },
                    { "62", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 62", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 28, 0, DateTimeKind.Utc) },
                    { "63", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 63", new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 4, 2, 12, 29, 0, DateTimeKind.Utc) },
                    { "64", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 64", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 10, 0, DateTimeKind.Utc) },
                    { "65", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 65", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 11, 0, DateTimeKind.Utc) },
                    { "66", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 66", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 12, 0, DateTimeKind.Utc) },
                    { "67", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 67", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 13, 0, DateTimeKind.Utc) },
                    { "68", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 68", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 14, 0, DateTimeKind.Utc) },
                    { "69", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 69", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 15, 0, DateTimeKind.Utc) },
                    { "7", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 7", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 16, 0, DateTimeKind.Utc) },
                    { "70", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 70", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 16, 0, DateTimeKind.Utc) },
                    { "71", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 71", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 17, 0, DateTimeKind.Utc) },
                    { "72", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 72", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 18, 0, DateTimeKind.Utc) },
                    { "73", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 73", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 19, 0, DateTimeKind.Utc) },
                    { "74", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 74", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 20, 0, DateTimeKind.Utc) },
                    { "75", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 75", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 21, 0, DateTimeKind.Utc) },
                    { "76", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 76", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 22, 0, DateTimeKind.Utc) },
                    { "77", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 77", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 23, 0, DateTimeKind.Utc) },
                    { "78", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 78", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 24, 0, DateTimeKind.Utc) },
                    { "79", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 79", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 25, 0, DateTimeKind.Utc) },
                    { "8", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 8", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 17, 0, DateTimeKind.Utc) },
                    { "80", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 80", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 26, 0, DateTimeKind.Utc) },
                    { "81", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 81", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 27, 0, DateTimeKind.Utc) },
                    { "82", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 82", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 28, 0, DateTimeKind.Utc) },
                    { "83", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 83", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 29, 0, DateTimeKind.Utc) },
                    { "84", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 84", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 30, 0, DateTimeKind.Utc) },
                    { "85", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 85", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 31, 0, DateTimeKind.Utc) },
                    { "86", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 86", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 32, 0, DateTimeKind.Utc) },
                    { "87", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 87", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 33, 0, DateTimeKind.Utc) },
                    { "88", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 88", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 5, 2, 12, 34, 0, DateTimeKind.Utc) },
                    { "9", "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPG", "user1", "Test Message 9", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 2, 12, 18, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
