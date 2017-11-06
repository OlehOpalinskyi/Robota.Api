using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Robota.api.Models;
using Robota.api.Contracts;
using static Robota.Data.Models.PersonDataModel;

namespace Robota.api.Controllers
{
    [RoutePrefix("api/persons")]
    [Authorize]
    public class PersonController : ApiController
    {
        private readonly IPersonRepo _personRepo;

        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<PersonViewModel>))]
        public IEnumerable<PersonViewModel> GetPersons()
        {
            return _personRepo.GetPersons();
        }

        [HttpGet]
        [Route("by-category/{categoryId}")]
        public IEnumerable<PersonViewModel> ByCategory(int categoryId)
        {
            return _personRepo.ByCategory(categoryId);
        }

        [HttpGet]
        [Route("by-name/{categoryId}/{name}")]
        public IEnumerable<PersonViewModel> ByName(int categoryId, string name)
        {
            return _personRepo.ByName(categoryId, name);
        }

        [HttpGet]
        [Route("filtered")]
        public IEnumerable<PersonViewModel> Filter(int categoryId, Man sex, int minAge, int maxAge)
        {
            return _personRepo.Filtered(categoryId, sex, minAge, maxAge);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(PersonViewModel))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            var personViewModel = await _personRepo.GetPerson(id);
            if (personViewModel == null)
            {
                return NotFound();
            }

            return Ok(personViewModel);
        }

        [HttpPut]
        [Route("edit/{id}")]
        [ResponseType(typeof(PersonViewModel))]
        public IHttpActionResult Edit(int id, PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatePerson =  _personRepo.Edit(id, personViewModel);

            return Ok(updatePerson);
        }

        [HttpPost]
        [Route("create")]
        [ResponseType(typeof(PersonViewModel))]
        public IHttpActionResult Create(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = _personRepo.Create(personViewModel);

            return Ok(person);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [ResponseType(typeof(PersonViewModel))]
        public IHttpActionResult DeletePersonViewModel(int id)
        {
            _personRepo.DeletePersonViewModel(id);

            return Ok();
        }
    }
}