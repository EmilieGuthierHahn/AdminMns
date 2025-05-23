using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminMns.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetupWithDisneySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    IdAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Justificatif = table.Column<string>(type: "longtext", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDeclaration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdStagiaire = table.Column<int>(type: "int", nullable: false),
                    IdRaisonAbsence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.IdAbsence);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administrateurs",
                columns: table => new
                {
                    IdAdministrateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false),
                    Prenom = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Telephone = table.Column<string>(type: "longtext", nullable: false),
                    Adresse = table.Column<string>(type: "longtext", nullable: false),
                    Ville = table.Column<string>(type: "longtext", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDeCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.IdAdministrateur);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    IdCandidature = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdStagiaire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.IdCandidature);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    IdCandidature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.IdClasse);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClasseStagiaires",
                columns: table => new
                {
                    IdStagiaire = table.Column<int>(type: "int", nullable: false),
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseStagiaires", x => new { x.IdStagiaire, x.IdClasse });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoursIntervenants",
                columns: table => new
                {
                    IdPlanning = table.Column<int>(type: "int", nullable: false),
                    IdIntervenant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursIntervenants", x => new { x.IdPlanning, x.IdIntervenant });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    IdDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false),
                    IdTypeDoc = table.Column<string>(type: "longtext", nullable: false),
                    IdCandidature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.IdDocument);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entretiens",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdRendezVous = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entretiens", x => new { x.IdUtilisateur, x.IdRendezVous });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Intervenants",
                columns: table => new
                {
                    IdIntervenant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false),
                    Prenom = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Specialite = table.Column<string>(type: "longtext", nullable: false),
                    Telephone = table.Column<string>(type: "longtext", nullable: false),
                    Adresse = table.Column<string>(type: "longtext", nullable: false),
                    Ville = table.Column<string>(type: "longtext", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDeCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervenants", x => x.IdIntervenant);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    IdPhoto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdClasse = table.Column<int>(type: "int", nullable: false),
                    IdStagiaire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.IdPhoto);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlanningClasses",
                columns: table => new
                {
                    IdPlanning = table.Column<int>(type: "int", nullable: false),
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningClasses", x => new { x.IdPlanning, x.IdClasse });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    IdPlanning = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Jour = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Heure = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Salle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.IdPlanning);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaisonsAbsence",
                columns: table => new
                {
                    IdRaisonAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaisonsAbsence", x => x.IdRaisonAbsence);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaisonsRetard",
                columns: table => new
                {
                    IdRaisonRetard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaisonsRetard", x => x.IdRaisonRetard);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    IdRendezVous = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JourRdv = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HeureRdv = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Sujet = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.IdRendezVous);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Retards",
                columns: table => new
                {
                    IdRetard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateArrivee = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Justificatif = table.Column<string>(type: "longtext", nullable: true),
                    IdRaisonRetard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retards", x => x.IdRetard);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetardStagiaires",
                columns: table => new
                {
                    IdStagiaire = table.Column<int>(type: "int", nullable: false),
                    IdRetard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetardStagiaires", x => new { x.IdStagiaire, x.IdRetard });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stagiaires",
                columns: table => new
                {
                    IdStagiaire = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false),
                    Prenom = table.Column<string>(type: "longtext", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmailStagiaire = table.Column<string>(type: "longtext", nullable: false),
                    Telephone = table.Column<string>(type: "longtext", nullable: false),
                    Adresse = table.Column<string>(type: "longtext", nullable: false),
                    Ville = table.Column<string>(type: "longtext", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stagiaires", x => x.IdStagiaire);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.IdStatus);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeDocs",
                columns: table => new
                {
                    IdTypeDoc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocs", x => x.IdTypeDoc);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MotDePasse = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CoursIntervenants",
                columns: new[] { "IdIntervenant", "IdPlanning" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Intervenants",
                columns: new[] { "IdIntervenant", "Adresse", "DateDeCreation", "DateDeNaissance", "Email", "IdUtilisateur", "Nom", "Prenom", "Specialite", "Telephone", "Ville" },
                values: new object[,]
                {
                    { 1, "Canardville Docks", new DateTime(2025, 5, 13, 14, 17, 11, 702, DateTimeKind.Local).AddTicks(1350), null, "donald.prof@disney.com", 3, "Duck", "Donald", "Gestion de la Colère et Navigation", "555-QUACK", "Canardville" },
                    { 2, "Chez Cendrillon", new DateTime(2025, 5, 13, 14, 17, 11, 704, DateTimeKind.Local).AddTicks(3594), null, "fairy.godmother@disney.com", 2, "Fairy", "Godmother", "Transformations Magiques", "555-MAGIC", "Royaume Enchanté" }
                });

            migrationBuilder.InsertData(
                table: "Plannings",
                columns: new[] { "IdPlanning", "Heure", "Jour", "Salle" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 10, 0, 0, 0), new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 101 },
                    { 2, new TimeSpan(0, 14, 0, 0, 0), new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 202 },
                    { 3, new TimeSpan(0, 9, 30, 0, 0), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), 101 }
                });

            migrationBuilder.InsertData(
                table: "Stagiaires",
                columns: new[] { "IdStagiaire", "Adresse", "DateNaissance", "EmailStagiaire", "IdUtilisateur", "Nom", "Prenom", "Telephone", "Ville" },
                values: new object[,]
                {
                    { 1, "1 Main Street", new DateTime(1928, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mickey.stagiaire@disney.com", 1, "Mouse", "Mickey", "111-222-3333", "Disneyland" },
                    { 2, "Château de Glace", new DateTime(1821, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "elsa.stagiaire@disney.com", 4, "Arendelle", "Elsa", "444-555-6666", "Arendelle" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "IdUtilisateur", "Email", "MotDePasse" },
                values: new object[,]
                {
                    { 1, "mickey.mouse@disney.com", "Password123!" },
                    { 2, "minnie.mouse@disney.com", "MinniePass!" },
                    { 3, "donald.duck@disney.com", "QuackQuack!" },
                    { 4, "elsa.arendelle@disney.com", "LetItGo!" },
                    { 5, "simba.lion@disney.com", "HakunaMatata!" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "IdStatus", "Type" },
                values: new object[,]
                {
                    { 1, "Approuvé par le Roi Lion" },
                    { 2, "En attente de la Fée Clochette" },
                    { 3, "Rejeté par Maléfique" },
                    { 4, "Magie en cours" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Administrateurs");

            migrationBuilder.DropTable(
                name: "Candidatures");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "ClasseStagiaires");

            migrationBuilder.DropTable(
                name: "CoursIntervenants");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Entretiens");

            migrationBuilder.DropTable(
                name: "Intervenants");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PlanningClasses");

            migrationBuilder.DropTable(
                name: "Plannings");

            migrationBuilder.DropTable(
                name: "RaisonsAbsence");

            migrationBuilder.DropTable(
                name: "RaisonsRetard");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "Retards");

            migrationBuilder.DropTable(
                name: "RetardStagiaires");

            migrationBuilder.DropTable(
                name: "Stagiaires");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "TypeDocs");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
