using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 5, 3, 20, 23, 429, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 5, 3, 20, 23, 432, DateTimeKind.Local).AddTicks(8314), "Instaclan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsLegalAge", "LastName", "NickName", "Password", "PortalId", "RoleId", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 523, DateTimeKind.Local).AddTicks(8632), null, "admin01@example.com", "admin01", true, "del portal1", "admin01", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1, 1, null },
                    { 2, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(4695), null, "Alvaro@example.com", "Alvaro", true, "del portal1", "Alvaro", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1, 2, null },
                    { 3, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(4991), null, "Andrea@example.com", "Andrea", true, "del portal1", "Andrea", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1, 2, null },
                    { 4, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5293), null, "random01@example.com", "random01", true, "del portal1", "random01", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1, 2, null },
                    { 5, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5554), null, "admin02@example.com", "admin02", true, "del portal2", "admin02", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 2, 1, null },
                    { 6, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(5869), null, "Maya@example.com", "Maya", true, "del portal2", "Maya", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 2, 2, null },
                    { 7, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(6068), null, "Emmanuel@example.com", "Emmanuel", true, "del portal2", "Emmanuel", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 2, 2, null },
                    { 8, new DateTime(1999, 4, 30, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 5, 3, 20, 23, 524, DateTimeKind.Local).AddTicks(6256), null, "random02@example.com", "random02", true, "del portal2", "random02", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "DeletedAt", "PostId", "Title", "UpdateAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Hola, soy admin01", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(66), null, 3, "Comentario1", null, 1 },
                    { 11, "Lorem ipsum prueba, 3", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(159), null, 3, "Comentario11", null, 1 },
                    { 2, "Hola, soy Alvaro", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(853), null, 4, "Comentario2", null, 2 },
                    { 12, "Lorem ipsum prueba, 4", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(869), null, 4, "Comentario12", null, 2 },
                    { 3, "Hola, soy Andrea", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(894), null, 4, "Comentario3", null, 3 },
                    { 13, "Lorem ipsum prueba, 4", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1117), null, 4, "Comentario13", null, 3 },
                    { 4, "Hola, soy random01", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1165), null, 3, "Comentario4", null, 4 },
                    { 14, "Lorem ipsum prueba, 3", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1177), null, 3, "Comentario14", null, 4 },
                    { 5, "Hola, soy admin02", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1198), null, 7, "Comentario5", null, 5 },
                    { 15, "Lorem ipsum prueba, 7", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1210), null, 7, "Comentario15", null, 5 },
                    { 6, "Hola, soy Maya", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1234), null, 7, "Comentario6", null, 6 },
                    { 16, "Lorem ipsum prueba, 7", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1247), null, 7, "Comentario16", null, 6 },
                    { 7, "Hola, soy Emmanuel", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1265), null, 7, "Comentario7", null, 7 },
                    { 17, "Lorem ipsum prueba, 7", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1276), null, 7, "Comentario17", null, 7 },
                    { 8, "Hola, soy random02", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1293), null, 8, "Comentario8", null, 8 },
                    { 18, "Lorem ipsum prueba, 8", new DateTime(2021, 9, 5, 3, 20, 23, 538, DateTimeKind.Local).AddTicks(1304), null, 8, "Comentario18", null, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 23, 59, 13, 914, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 8, 29, 23, 59, 13, 918, DateTimeKind.Local).AddTicks(8584), "Instagum" });
        }
    }
}
