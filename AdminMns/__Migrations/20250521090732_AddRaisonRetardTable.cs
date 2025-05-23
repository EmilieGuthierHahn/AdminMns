using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class AddRaisonRetardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaisonsRetard",
                table: "RaisonsRetard");

            migrationBuilder.RenameTable(
                name: "RaisonsRetard",
                newName: "raisons_retard");

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "raisons_retard",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_raisons_retard",
                table: "raisons_retard",
                column: "IdRaisonRetard");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_raisons_retard",
                table: "raisons_retard");

            migrationBuilder.RenameTable(
                name: "raisons_retard",
                newName: "RaisonsRetard");

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsRetard",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaisonsRetard",
                table: "RaisonsRetard",
                column: "IdRaisonRetard");

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 53, 52, 770, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 21, 10, 53, 52, 773, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1,
                column: "DateSoumission",
                value: new DateTime(2025, 3, 21, 8, 53, 52, 769, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2,
                column: "DateSoumission",
                value: new DateTime(2025, 4, 21, 8, 53, 52, 769, DateTimeKind.Utc).AddTicks(9693));
        }
    }
}
