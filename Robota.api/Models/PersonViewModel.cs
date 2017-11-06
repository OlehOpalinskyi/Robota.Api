using System.ComponentModel.DataAnnotations;
using static Robota.Data.Models.PersonDataModel;

namespace Robota.api.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }

        public string Address { get; set; }
        public Man Sex { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}