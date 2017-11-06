using Robota.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Robota.Data.Models.PersonDataModel;

namespace Robota.api.Contracts
{
    public interface IPersonRepo
    {
        IEnumerable<PersonViewModel> GetPersons();
        IEnumerable<PersonViewModel> ByCategory(int categoryId);
        IEnumerable<PersonViewModel> ByName(int categoryId, string name);
        Task<PersonViewModel> GetPerson(int id);
        PersonViewModel Edit(int id, PersonViewModel personViewModel);
        PersonViewModel Create(PersonViewModel personViewModel);
        void DeletePersonViewModel(int id);
        IEnumerable<PersonViewModel> Filtered(int categoryId, Man sex, int minAge, int maxAge);
    }
}
