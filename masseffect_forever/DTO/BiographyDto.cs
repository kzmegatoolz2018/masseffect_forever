using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.DTO
{
    public class BiographyDto
    {
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        
        public string Birthplace { get; set; } = string.Empty;
        
        public string Background { get; set; } = string.Empty;
        
        public string PsychologicalProfile { get; set; } = string.Empty;
        
        public string MilitaryHistory { get; set; } = string.Empty;
    }
    
    public class BiographyCreateDto
    {
        [Required(ErrorMessage = "ID персонажа обязателен")]
        public int CharacterId { get; set; }
        
        public string Birthplace { get; set; } = string.Empty;
        
        public string Background { get; set; } = string.Empty;
        
        public string PsychologicalProfile { get; set; } = string.Empty;
        
        public string MilitaryHistory { get; set; } = string.Empty;
    }
    
    public class BiographyUpdateDto
    {
        public string Birthplace { get; set; } = string.Empty;
        
        public string Background { get; set; } = string.Empty;
        
        public string PsychologicalProfile { get; set; } = string.Empty;
        
        public string MilitaryHistory { get; set; } = string.Empty;
    }
}
