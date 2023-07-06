using System.ComponentModel.DataAnnotations;

namespace FateCharactersAPI
{
    public class FateCharacter
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ServantName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Class { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string NoblePhantasm { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Origin { get; set; } = string.Empty;  
    }
}
