using AdminMns.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminMns.Data // Namespace correspondant au dossier 'Data'
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ajoutez un DbSet pour chaque modèle/table que vous voulez gérer via EF Core
        // Le nom du DbSet est généralement le pluriel du nom de la classe modèle.
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Classe> Classes { get; set; } = null!;
        public DbSet<Candidature> Candidatures { get; set; } = null!;
        public DbSet<ClasseStagiaire> ClasseStagiaires { get; set; } // Table de liaison
        public DbSet<CoursIntervenant> CoursIntervenants { get; set; } // Table de liaison
        public DbSet<Document> Documents { get; set; }
        public DbSet<Entretien> Entretiens { get; set; } // Table de liaison (anciennement 'entretenir')
        public DbSet<Intervenant> Intervenants { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PlanningClasse> PlanningClasses { get; set; } // Table de liaison (anciennement 'planifier')
        public DbSet<Planning> Plannings { get; set; }
        public DbSet<RaisonAbsence> RaisonsAbsence { get; set; } = null!;
        public DbSet<RaisonRetard> RaisonsRetard { get; set; } = null!;
        public DbSet<RendezVous> RendezVous { get; set; } // Pluriel irrégulier mais commun
        public DbSet<Retard> Retards { get; set; } = null!;
        public DbSet<RetardStagiaire> RetardStagiaires { get; set; } = null!;
        public DbSet<Stagiaire> Stagiaires { get; set; }
        public DbSet<Status> Statuses { get; set; } // Status est déjà pluriel/invariable
        public DbSet<TypeDoc> TypeDocs { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        // Vous pouvez ajouter ici la configuration pour les clés composites
        // des tables de liaison si nécessaire (dans OnModelCreating)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration exemple pour clé composite (à adapter pour chaque table de liaison)
            modelBuilder.Entity<ClasseStagiaire>()
                .HasKey(cs => new { cs.IdStagiaire, cs.IdClasse }); // Définit la clé composite

            modelBuilder.Entity<CoursIntervenant>()
                .HasKey(ci => new { ci.IdPlanning, ci.IdIntervenant });

            modelBuilder.Entity<Entretien>()
                .HasKey(e => new { e.IdUtilisateur, e.IdRendezVous });

            modelBuilder.Entity<PlanningClasse>()
               .HasKey(pc => new { pc.IdPlanning, pc.IdClasse });


            modelBuilder.Entity<RetardStagiaire>(entity => // Vous pouvez utiliser 'entity =>' pour chaîner les configurations
            {
                // Définit la clé primaire composite
                entity.HasKey(rs => new { rs.IdRetard, rs.IdStagiaire });

                // Relation: RetardStagiaire -> Retard (Un RetardStagiaire appartient à UN Retard)
                entity.HasOne(rs => rs.Retard)
                    .WithMany(r => r.RetardStagiaires) // Un Retard a PLUSIEURS RetardStagiaire
                    .HasForeignKey(rs => rs.IdRetard);

                // Relation: RetardStagiaire -> Stagiaire (Un RetardStagiaire appartient à UN Stagiaire)
                entity.HasOne(rs => rs.Stagiaire)
                    .WithMany(s => s.RetardStagiaires) // Un Stagiaire a PLUSIEURS RetardStagiaire
                    .HasForeignKey(rs => rs.IdStagiaire);
            });



            modelBuilder.Entity<Candidature>().HasData(
    new Candidature { IdCandidature = 1, TitreOuReference = "Candidature Alpha - Session 2025", DateSoumission = DateTime.UtcNow.AddMonths(-2) },
    new Candidature { IdCandidature = 2, TitreOuReference = "Candidature Bravo - Session 2026", DateSoumission = DateTime.UtcNow.AddMonths(-1) }
);

            modelBuilder.Entity<Utilisateur>().HasData(
    new Utilisateur { IdUtilisateur = 1, Email = "mickey.mouse@disney.com", MotDePasse = "Password123!" }, // MDP à hasher en vrai
    new Utilisateur { IdUtilisateur = 2, Email = "minnie.mouse@disney.com", MotDePasse = "MinniePass!" },
    new Utilisateur { IdUtilisateur = 3, Email = "donald.duck@disney.com", MotDePasse = "QuackQuack!" },
    new Utilisateur { IdUtilisateur = 4, Email = "elsa.arendelle@disney.com", MotDePasse = "LetItGo!" },
    new Utilisateur { IdUtilisateur = 5, Email = "simba.lion@disney.com", MotDePasse = "HakunaMatata!" }
);
            modelBuilder.Entity<Status>().HasData(
    new Status { IdStatus = 1, Type = "Approuvé par le Roi Lion" },
    new Status { IdStatus = 2, Type = "En attente de la Fée Clochette" },
    new Status { IdStatus = 3, Type = "Rejeté par Maléfique" },
    new Status { IdStatus = 4, Type = "Magie en cours" }
);
            modelBuilder.Entity<Stagiaire>().HasData(
    new Stagiaire
    {
        IdStagiaire = 1,
        Nom = "Mouse",
        Prenom = "Mickey",
        DateNaissance = new DateTime(1928, 11, 18),
        EmailStagiaire = "mickey.stagiaire@disney.com",
        Telephone = "111-222-3333",
        Adresse = "1 Main Street",
        Ville = "Disneyland",
        IdUtilisateur = 1 // Mickey est l'utilisateur 1
    },
    new Stagiaire
    {
        IdStagiaire = 2,
        Nom = "Arendelle",
        Prenom = "Elsa",
        DateNaissance = new DateTime(1821, 12, 21), // Date fictive
        EmailStagiaire = "elsa.stagiaire@disney.com",
        Telephone = "444-555-6666",
        Adresse = "Château de Glace",
        Ville = "Arendelle",
        IdUtilisateur = 4 // Elsa est l'utilisateur 4
    }
);
            modelBuilder.Entity<Intervenant>().HasData(
    new Intervenant
    {
        IdIntervenant = 1,
        Nom = "Duck",
        Prenom = "Donald",
        Email = "donald.prof@disney.com",
        Specialite = "Gestion de la Colère et Navigation",
        DateDeCreation = DateTime.Now,
        IdUtilisateur = 3, // Donald est l'utilisateur 3
        // Remplissez les autres champs obligatoires (téléphone, adresse, ville) avec des valeurs fictives
        Telephone = "555-QUACK",
        Adresse = "Canardville Docks",
        Ville = "Canardville"
    },
    new Intervenant
    {
        IdIntervenant = 2,
        Nom = "Fairy",
        Prenom = "Godmother",
        Email = "fairy.godmother@disney.com",
        Specialite = "Transformations Magiques",
        DateDeCreation = DateTime.Now,
        IdUtilisateur = 2, // Supposons que Minnie soit aussi une intervenante via son compte utilisateur
        Telephone = "555-MAGIC",
        Adresse = "Chez Cendrillon",
        Ville = "Royaume Enchanté"
    }
);
            var today = DateTime.Today; // Pour avoir des dates relatives
            modelBuilder.Entity<Planning>().ToTable("plannings").HasData(
                new Planning { IdPlanning = 1, Jour = today.AddDays(1), Heure = new TimeSpan(10, 0, 0), Salle = 101 }, // Demain 10h, Salle 101
                new Planning { IdPlanning = 2, Jour = today.AddDays(1), Heure = new TimeSpan(14, 0, 0), Salle = 202 }, // Demain 14h, Salle 202
                new Planning { IdPlanning = 3, Jour = today.AddDays(2), Heure = new TimeSpan(9, 30, 0), Salle = 101 }  // Après-demain 9h30, Salle 101
            );
            modelBuilder.Entity<CoursIntervenant>().HasData(
    new CoursIntervenant { IdPlanning = 1, IdIntervenant = 1 }, // Planning 1 (Demain 10h) avec Intervenant 1 (Donald)
    new CoursIntervenant { IdPlanning = 2, IdIntervenant = 2 }, // Planning 2 (Demain 14h) avec Intervenant 2 (Fairy Godmother)
    new CoursIntervenant { IdPlanning = 3, IdIntervenant = 1 }  // Planning 3 (Après-demain 9h30) avec Intervenant 1 (Donald)
);


            // Ajoutez ici d'autres configurations si nécessaire (relations, etc.)
        }
    }
}
