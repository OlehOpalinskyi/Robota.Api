using System.ComponentModel.DataAnnotations.Schema;

namespace Robota.Data.Models
{
    [Table("Persons")]
    public class PersonDataModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Man Sex { get; set; }

        public virtual CategoryDataModel Category { get; set; }

        public enum Man
        {
            Male = 1,
            Female = 2
        }
    }
}
