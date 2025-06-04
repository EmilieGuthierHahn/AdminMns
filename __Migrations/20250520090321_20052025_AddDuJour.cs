using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class _20052025_AddDuJour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidatures",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "DateValidation",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "IdStagiaire",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Candidatures");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "classes");

            migrationBuilder.RenameTable(
                name: "Candidatures",
                newName: "candidatures");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "classes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSoumission",
                table: "candidatures",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitreOuReference",
                table: "candidatures",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classes",
                table: "classes",
                column: "IdClasse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidatures",
                table: "candidatures",
                column: "IdCandidature");

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

            migrationBuilder.InsertData(
                table: "candidatures",
                columns: new[] { "IdCandidature", "DateSoumission", "TitreOuReference" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 20, 9, 3, 20, 718, DateTimeKind.Utc).AddTicks(161), "Candidature Alpha - Session 2025" },
                    { 2, new DateTime(2025, 4, 20, 9, 3, 20, 718, DateTimeKind.Utc).AddTicks(548), "Candidature Bravo - Session 2026" }
                });

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 1,
                column: "Jour",
                value: new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 2,
                column: "Jour",
                value: new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 3,
                column: "Jour",
                value: new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_classes_IdCandidature",
                table: "classes",
                column: "IdCandidature");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_candidatures_IdCandidature",
                table: "classes",
                column: "IdCandidature",
                principalTable: "candidatures",
                principalColumn: "IdCandidature",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_candidatures_IdCandidature",
                table: "classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classes",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_IdCandidature",
                table: "classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidatures",
                table: "candidatures");

            migrationBuilder.DeleteData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "candidatures",
                keyColumn: "IdCandidature",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DateSoumission",
                table: "candidatures");

            migrationBuilder.DropColumn(
                name: "TitreOuReference",
                table: "candidatures");

            migrationBuilder.RenameTable(
                name: "classes",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "candidatures",
                newName: "Candidatures");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Classes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Candidatures",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateValidation",
                table: "Candidatures",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdStagiaire",
                table: "Candidatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Candidatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "IdClasse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidatures",
                table: "Candidatures",
                column: "IdCandidature");

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 14, 14, 43, 26, 822, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 14, 14, 43, 26, 824, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 1,
                column: "Jour",
                value: new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 2,
                column: "Jour",
                value: new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "plannings",
                keyColumn: "IdPlanning",
                keyValue: 3,
                column: "Jour",
                value: new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
