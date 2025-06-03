using AdminMns.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminMns.Data // Namespace correspondant au dossier 'Data'
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Retard> Retards { get; set; }
        public DbSet<Stagiaire> Stagiaires { get; set; }
        public DbSet<TypeDoc> TypeDocs { get; set; }
    }
}
