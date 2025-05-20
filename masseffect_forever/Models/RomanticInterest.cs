using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace masseffect_forever.Models
{
    public class RomanticInterest
    {
        [Key]
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        
        [ForeignKey("CharacterId")]
        public Character Character { get; set; } = null!;
        
        public string AvailableFor { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string CompatibleChoices { get; set; } = string.Empty;
        
        public string RelationshipArc { get; set; } = string.Empty;
        
        public bool IsExclusive { get; set; }
    }
}
