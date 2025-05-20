using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.DTO
{
    public class RomanticInterestDto
    {
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        
        public string CharacterName { get; set; } = string.Empty;
        
        public string AvailableFor { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string CompatibleChoices { get; set; } = string.Empty;
        
        public string RelationshipArc { get; set; } = string.Empty;
        
        public bool IsExclusive { get; set; }
    }
    
    public class RomanticInterestCreateDto
    {
        [Required(ErrorMessage = "ID персонажа обязателен")]
        public int CharacterId { get; set; }
        
        public string AvailableFor { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string CompatibleChoices { get; set; } = string.Empty;
        
        public string RelationshipArc { get; set; } = string.Empty;
        
        public bool IsExclusive { get; set; }
    }
    
    public class RomanticInterestUpdateDto
    {
        public string AvailableFor { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string CompatibleChoices { get; set; } = string.Empty;
        
        public string RelationshipArc { get; set; } = string.Empty;
        
        public bool IsExclusive { get; set; }
    }
}
