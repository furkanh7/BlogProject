using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"), "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(8335), null, null, false, null, null, "Asp.Net Core" },
                    { new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"), "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(8350), null, null, false, null, null, "Visual Studio 2022" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("0098218f-ef1f-4571-a582-7205f1380c05"), "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(9166), null, null, "images/vstest", "png", false, null, null },
                    { new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"), "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(9163), null, null, "images/testimage", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1305e3da-16a7-4446-a86a-64415c8e4290"), new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"), "Asp.Net Core Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(7195), null, null, new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 },
                    { new Guid("75f1febb-3473-4c82-9bbf-86af08c76bb0"), new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"), "Visual Studio Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(7198), null, null, new Guid("0098218f-ef1f-4571-a582-7205f1380c05"), false, null, null, "Visual Studio Deneme Makalesi", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1305e3da-16a7-4446-a86a-64415c8e4290"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("75f1febb-3473-4c82-9bbf-86af08c76bb0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("0098218f-ef1f-4571-a582-7205f1380c05"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"));
        }
    }
}
