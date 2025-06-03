
using System.ComponentModel.DataAnnotations; // Pour [Key]

namespace AdminMns.Models // Assurez-vous que le namespace est correct
{
    // Correspond à la table 'type_doc'
    public class TypeDoc
    {
        [Key]
        [MaxLength(50)]
        public required string IdTypeDoc { get; set; }
        [MaxLength(50)]
        public required string Description { get; set; }
    }
}
