using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.DTO
{
    public class CharacterDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Имя персонажа обязательно")]
        public string Name { get; set; } = string.Empty;
        
        public string Species { get; set; } = string.Empty;
        
        public string Class { get; set; } = string.Empty;
        
        public string Gender { get; set; } = string.Empty;
        
        public string Affiliation { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        
        public DateTime? FirstAppearance { get; set; }
        
        public DateTime? LastAppearance { get; set; }
        
       
        public BiographyDto? Biography { get; set; }
        
        public ICollection<RomanticInterestDto>? RomanticInterests { get; set; }
    }
    
    public class CharacterCreateDto
    {
        [Required(ErrorMessage = "Имя персонажа обязательно")]
        public string Name { get; set; } = string.Empty;
        
        public string Species { get; set; } = string.Empty;
        
        public string Class { get; set; } = string.Empty;
        
        public string Gender { get; set; } = string.Empty;
        
        public string Affiliation { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        
        public DateTime? FirstAppearance { get; set; }
        
        public DateTime? LastAppearance { get; set; }
    }
    
    public class CharacterUpdateDto
    {
        [Required(ErrorMessage = "Имя персонажа обязательно")]
        public string Name { get; set; } = string.Empty;
        
        public string Species { get; set; } = string.Empty;
        
        public string Class { get; set; } = string.Empty;
        
        public string Gender { get; set; } = string.Empty;
        
        public string Affiliation { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        
        public DateTime? FirstAppearance { get; set; }
        
        public DateTime? LastAppearance { get; set; }
    }
}
