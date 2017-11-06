using Robota.api.Contracts;
using System.Collections.Generic;
using System.Linq;
using static AutoMapper.Mapper;
using Robota.api.Models;
using Robota.Data;
using System.Threading.Tasks;
using Robota.Data.Models;
using static Robota.Data.Models.PersonDataModel;

namespace Robota.api.Services
{
    public class PersonRepo : IPersonRepo
    {
        private readonly RobotaContext _dataContext;

        public PersonRepo(RobotaContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<PersonViewModel> ByCategory(int categoryId)
        {
            var persons = _dataContext.Persons.Where(p => p.Category.Id == categoryId);

            return Map<IEnumerable<PersonViewModel>>(persons);
        }

        public IEnumerable<PersonViewModel> ByName(int categoryId, string name)
        {

            var persons = _dataContext.Persons.Where(p => p.Category.Id == categoryId && p.FullName.Contains(name));

            return Map<IEnumerable<PersonViewModel>>(persons);
        }

        public PersonViewModel Create(PersonViewModel personViewModel)
        {
            var category = _dataContext.Categories.Single(c => c.Id == personViewModel.CategoryId);
            var dataPerson = Map<PersonDataModel>(personViewModel);
            dataPerson.Category = category;
            _dataContext.Persons.Add(dataPerson);
            _dataContext.SaveChanges();

            return Map<PersonViewModel>(dataPerson);
        }

        public void DeletePersonViewModel(int id)
        {
            var person = _dataContext.Persons.Single(p => p.Id == id);
            _dataContext.Persons.Remove(person);
            _dataContext.SaveChanges();
        }

        public PersonViewModel Edit(int id, PersonViewModel personViewModel)
        {
            var originPerson = _dataContext.Persons.Single(p => p.Id == id);
            var dataPerson = Map<PersonDataModel>(personViewModel);
            var category = _dataContext.Categories.Single(c => c.Id == personViewModel.CategoryId);
            dataPerson.Category = category;
            dataPerson.Id = id;
            _dataContext.Entry(originPerson).CurrentValues.SetValues(dataPerson);

            _dataContext.SaveChanges();
            return Map<PersonViewModel>(originPerson);
        }

        public IEnumerable<PersonViewModel> Filtered(int categoryId, Man sex, int minAge, int maxAge)
        {
            var persons = _dataContext.Persons.Where(p => p.Category.Id == categoryId).ToList();

            var filteredPersons = persons.Where(p => p.Sex == sex && p.Age <= maxAge && p.Age >= minAge).ToList();

            return Map<IEnumerable<PersonViewModel>>(filteredPersons);
        }

        public async Task<PersonViewModel> GetPerson(int id)
        {
            var personViewModel = await _dataContext.Persons.FindAsync(id);

            return Map<PersonViewModel>(personViewModel);
        }

        public IEnumerable<PersonViewModel> GetPersons()
        {
            var persons = _dataContext.Persons.ToList();
            return Map<IEnumerable<PersonViewModel>>(persons);
        }
    }
}