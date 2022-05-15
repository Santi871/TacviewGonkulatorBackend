using System.ComponentModel.DataAnnotations;

namespace TacviewGonkulatorBackend.Dtos
{
    public class TacviewCreateDto
    {
        [Required]
        public string FileName { get; set; }
        
        [Required]
        public string FileContent { get; set; }
    }
}