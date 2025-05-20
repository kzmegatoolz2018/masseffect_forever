using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace masseffect_forever.Models
{
    public class Biography
    {
        [Key]
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        
        [ForeignKey("CharacterId")]
        public Character Character { get; set; } = null!;
        
        public string Birthplace { get; set; } = string.Empty;
        
        public string Background { get; set; } = string.Empty;
        
        public string PsychologicalProfile { get; set; } = string.Empty;
        
        public string MilitaryHistory { get; set; } = string.Empty;
    }
}
