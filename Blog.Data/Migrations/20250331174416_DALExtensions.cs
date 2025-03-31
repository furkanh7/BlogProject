using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class DALExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1305e3da-16a7-4446-a86a-64415c8e4290"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("75f1febb-3473-4c82-9bbf-86af08c76bb0"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("437b682a-d13e-4267-bd84-170099a335db"), new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"), "Asp.Net Core Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(7802), null, null, new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 },
                    { new Guid("fac5698f-7ce5-4ded-8aa3-1ad2678849f4"), new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"), "Visual Studio Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(7826), null, null, new Guid("0098218f-ef1f-4571-a582-7205f1380c05"), false, null, null, "Visual Studio Deneme Makalesi", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("0098218f-ef1f-4571-a582-7205f1380c05"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 20, 44, 15, 624, DateTimeKind.Local).AddTicks(9861));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("437b682a-d13e-4267-bd84-170099a335db"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fac5698f-7ce5-4ded-8aa3-1ad2678849f4"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1305e3da-16a7-4446-a86a-64415c8e4290"), new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"), "Asp.Net Core Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(7195), null, null, new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 },
                    { new Guid("75f1febb-3473-4c82-9bbf-86af08c76bb0"), new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"), "Visual Studio Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(7198), null, null, new Guid("0098218f-ef1f-4571-a582-7205f1380c05"), false, null, null, "Visual Studio Deneme Makalesi", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("0098218f-ef1f-4571-a582-7205f1380c05"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 17, 43, 50, 0, DateTimeKind.Local).AddTicks(9163));
        }
    }
}
