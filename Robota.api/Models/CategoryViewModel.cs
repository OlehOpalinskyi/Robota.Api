using System.ComponentModel.DataAnnotations;

namespace Robota.api.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}