using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class _20052025_DeuxiemeTentative : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 3, 20, 718, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 20, 11, 3, 20, 721, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 20, 9, 3, 20, 718, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 20, 9, 3, 20, 718, DateTimeKind.Utc).AddTicks(548));
        }
    }
}
