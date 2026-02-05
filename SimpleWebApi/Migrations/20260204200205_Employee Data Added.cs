using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DateOfBirth", "Department", "EmployeeId", "EmployeeName", "Gender", "JoiningDate", "Phone" },
                values: new object[,]
                {
                    { 1, true, new DateOnly(1990, 1, 20), 1, "1001", "Alice", "Female", new DateOnly(2024, 6, 20), "953678982" },
                    { 2, true, new DateOnly(1999, 3, 11), 2, "1002", "John", "Male", new DateOnly(2020, 7, 22), "784778993" },
                    { 3, true, new DateOnly(2000, 5, 20), 1, "1003", "Molly", "Female", new DateOnly(2026, 6, 20), "34333" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
