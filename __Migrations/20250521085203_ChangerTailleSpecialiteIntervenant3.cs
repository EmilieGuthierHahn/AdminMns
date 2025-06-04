using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class ChangerTailleSpecialiteIntervenant3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 52, 2, 553, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 52, 2, 556, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 21, 8, 52, 2, 552, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 21, 8, 52, 2, 552, DateTimeKind.Utc).AddTicks(9970));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 51, 2, 909, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 51, 2, 912, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 21, 8, 51, 2, 908, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 21, 8, 51, 2, 908, DateTimeKind.Utc).AddTicks(9271));
        }
    }
}
