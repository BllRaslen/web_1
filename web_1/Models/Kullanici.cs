using System.ComponentModel.DataAnnotations;

namespace web_1.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } 
    }
}
