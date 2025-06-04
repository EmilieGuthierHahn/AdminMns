using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIntervenantSpecialiteLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Intervenants",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 44, 57, 846, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 44, 57, 849, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 20, 9, 44, 57, 845, DateTimeKind.Utc).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 20, 9, 44, 57, 845, DateTimeKind.Utc).AddTicks(8637));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 12, 22, 773, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 12, 22, 775, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 20, 9, 12, 22, 772, DateTimeKind.Utc).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 20, 9, 12, 22, 772, DateTimeKind.Utc).AddTicks(6306));
        }
    }
}
