using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilisateurNavigationToStagiaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plannings",
                table: "Plannings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stagiaires",
                table: "Stagiaires");

            migrationBuilder.RenameTable(
                name: "Utilisateurs",
                newName: "utilisateurs");

            migrationBuilder.RenameTable(
                name: "Plannings",
                newName: "plannings");

            migrationBuilder.RenameTable(
                name: "Stagiaires",
                newName: "stagiaire");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TypeDocs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Sujet",
                table: "RendezVous",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsRetard",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsAbsence",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Specialite",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Intervenants",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "IdTypeDoc",
                table: "Documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Administrateurs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Justificatif",
                table: "Absences",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "EmailStagiaire",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "stagiaire",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_utilisateurs",
                table: "utilisateurs",
                column: "IdUtilisateur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plannings",
                table: "plannings",
                column: "IdPlanning");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stagiaire",
                table: "stagiaire",
                column: "IdStagiaire");

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

            migrationBuilder.CreateIndex(
                name: "IX_stagiaire_IdUtilisateur",
                table: "stagiaire",
                column: "IdUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_stagiaire_utilisateurs_IdUtilisateur",
                table: "stagiaire",
                column: "IdUtilisateur",
                principalTable: "utilisateurs",
                principalColumn: "IdUtilisateur",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stagiaire_utilisateurs_IdUtilisateur",
                table: "stagiaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_utilisateurs",
                table: "utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plannings",
                table: "plannings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stagiaire",
                table: "stagiaire");

            migrationBuilder.DropIndex(
                name: "IX_stagiaire_IdUtilisateur",
                table: "stagiaire");

            migrationBuilder.RenameTable(
                name: "utilisateurs",
                newName: "Utilisateurs");

            migrationBuilder.RenameTable(
                name: "plannings",
                newName: "Plannings");

            migrationBuilder.RenameTable(
                name: "stagiaire",
                newName: "Stagiaires");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TypeDocs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Sujet",
                table: "RendezVous",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsRetard",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Motif",
                table: "RaisonsAbsence",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Specialite",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Intervenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Documents",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IdTypeDoc",
                table: "Documents",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Administrateurs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Justificatif",
                table: "Absences",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Ville",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmailStagiaire",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Stagiaires",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs",
                column: "IdUtilisateur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plannings",
                table: "Plannings",
                column: "IdPlanning");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stagiaires",
                table: "Stagiaires",
                column: "IdStagiaire");

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 1,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 13, 14, 17, 11, 702, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Intervenants",
                keyColumn: "IdIntervenant",
                keyValue: 2,
                column: "DateDeCreation",
                value: new DateTime(2025, 5, 13, 14, 17, 11, 704, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Plannings",
                keyColumn: "IdPlanning",
                keyValue: 1,
                column: "Jour",
                value: new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Plannings",
                keyColumn: "IdPlanning",
                keyValue: 2,
                column: "Jour",
                value: new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Plannings",
                keyColumn: "IdPlanning",
                keyValue: 3,
                column: "Jour",
                value: new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
