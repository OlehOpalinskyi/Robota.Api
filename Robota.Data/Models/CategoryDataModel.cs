using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robota.Data.Models
{
    [Table("Category")]
    public class CategoryDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonDataModel> Persons { get; set; }
    }
}
