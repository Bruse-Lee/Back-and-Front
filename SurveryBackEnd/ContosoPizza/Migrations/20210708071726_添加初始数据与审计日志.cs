using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoPizza.Migrations
{
    public partial class 添加初始数据与审计日志 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateTime", "DisplayOrder", "IsActived", "IsDeleted", "Password", "Remark", "UpdateTime", "Username" },
                values: new object[] { 1, new DateTime(2021, 7, 8, 15, 17, 25, 536, DateTimeKind.Local).AddTicks(1693), 0, false, false, "123", "暂无备注", new DateTime(2021, 7, 8, 15, 17, 25, 537, DateTimeKind.Local).AddTicks(260), "Root" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateTime", "DisplayOrder", "IsActived", "IsDeleted", "Password", "Remark", "UpdateTime", "Username" },
                values: new object[] { 2, new DateTime(2021, 7, 8, 15, 17, 25, 537, DateTimeKind.Local).AddTicks(1448), 0, false, false, "113", "暂无备注", new DateTime(2021, 7, 8, 15, 17, 25, 537, DateTimeKind.Local).AddTicks(1454), "Root2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
