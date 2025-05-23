using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("utilisateurs")] // Si le nom de table est en minuscules
public class Utilisateur
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUtilisateur { get; set; }
    [Required(ErrorMessage = "L'email est requis.")]
    [MaxLength(50, ErrorMessage = "L'email ne peut pas dépasser 50 caractères.")]
    [EmailAddress(ErrorMessage = "Format d'email invalide.")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [MaxLength(250)] // La BDD a varchar(250)
    public string MotDePasse { get; set; } = null!;
}