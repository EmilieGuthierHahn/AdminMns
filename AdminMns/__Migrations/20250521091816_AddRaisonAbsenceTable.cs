using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class AddRaisonAbsenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaisonsAbsence",
                table: "RaisonsAbsence");

            migrationBuilder.RenameTable(
                name: "RaisonsAbsence",
                newName: "raisons_absence");

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "raisons_absence",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_raisons_absence",
                table: "raisons_absence",
                column: "IdRaisonAbsence");

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 11, 18, 16, 111, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 11, 18, 16, 113, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 21, 9, 18, 16, 110, DateTimeKind.Utc).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 21, 9, 18, 16, 110, DateTimeKind.Utc).AddTicks(3585));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_raisons_absence",
                table: "raisons_absence");

            migrationBuilder.RenameTable(
                name: "raisons_absence",
                newName: "RaisonsAbsence");

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsAbsence",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaisonsAbsence",
                table: "RaisonsAbsence",
                column: "IdRaisonAbsence");

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 11, 7, 32, 433, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 11, 7, 32, 436, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 21, 9, 7, 32, 432, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 21, 9, 7, 32, 432, DateTimeKind.Utc).AddTicks(7947));
        }
    }
}
