using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("437b682a-d13e-4267-bd84-170099a335db"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fac5698f-7ce5-4ded-8aa3-1ad2678849f4"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("4f198614-e499-47df-a95b-bba820d4d9ac"), new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"), "Visual Studio Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(1201), null, null, new Guid("0098218f-ef1f-4571-a582-7205f1380c05"), false, null, null, "Visual Studio Deneme Makalesi", 15 },
                    { new Guid("baca7656-4d93-49e4-9ad1-00763272c3e3"), new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"), "Asp.Net Core Deneme Makalesi İçeriği", "Admin Test", new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(1197), null, null, new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4f5c6666-ed55-4db8-940b-cc07147dc819"), "282eabfe-7fc8-41ce-961b-43d34c65c821", "Admin", "ADMIN" },
                    { new Guid("540f4422-d968-450d-ac20-b114a089d1e2"), "913eae17-d008-4bf1-85c3-9e97902c4514", "User", "USER" },
                    { new Guid("6a2fcccd-9aad-476c-9996-8feeab844aa9"), "7fd2bb0e-c396-4a31-8791-21223ab9008a", "Superadmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2c1b93b8-66c6-4746-8250-73be6cd413cc"), 0, "c5c12b81-3b72-4d32-ad7a-700c4062e698", "admin@gmail.com", false, "admin", "user", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJ/KU24rAY8GHKayd2mU6mZm4p3YQWOCHo0k8BUrh9qiERuRHqvTSkxZ+DngacqqmQ==", "+905518888888", false, "b987cdeb-50a2-49fc-94b5-1ad98a6272a5", false, "admin@gmail.com" },
                    { new Guid("8cca96cd-db26-45f5-856c-443ffedbf79a"), 0, "ebbb8652-2192-4d8d-9a80-bda90282f2de", "superadmin@gmail.com", true, "furkan", "Hilal", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBMHuucM5GZC0U3n9H/bQc29wyo6+u35x21ZnB6VxbXA68O2eyC+d3G7mDAsQlYMNA==", "+905519999999", true, "60980d04-7a28-4ded-b373-789aeb873a53", false, "superadmin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7174f01e-fee2-48cd-9f7e-7008c33e2631"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd44fa31-719a-4fac-a99f-1b18c093e44e"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("0098218f-ef1f-4571-a582-7205f1380c05"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("445cc7dc-c06d-4027-9faf-b0741ab40f35"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 2, 16, 43, 47, 2, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f5c6666-ed55-4db8-940b-cc07147dc819"), new Guid("2c1b93b8-66c6-4746-8250-73be6cd413cc") },
                    { new Guid("6a2fcccd-9aad-476c-9996-8feeab844aa9"), new Guid("8cca96cd-db26-45f5-856c-443ffedbf79a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4f198614-e499-47df-a95b-bba820d4d9ac"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("baca7656-4d93-49e4-9ad1-00763272c3e3"));

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
    }
}
