using Robota.api.Contracts;
using Robota.api.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using static AutoMapper.Mapper;

namespace Robota.api.Controllers
{
    [RoutePrefix("api/category")]
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo repo)
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _categoryRepo.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryRepo.Get(id);
            if (category != null)
                return Ok(Map<CategoryViewModel>(category));
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult Create(CategoryViewModel category)
        {
            var dataCategory = _categoryRepo.Create(category);

            return Ok(dataCategory);
        }

        [HttpPut]
        [Route("edit")]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult Edit(int id, string name)
        {
            var category = _categoryRepo.Edit(id, name);

            return Ok(category);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult Delete(int id)
        {
            var category = _categoryRepo.Delete(id);
            
            return Ok(category);
        }
    }
}
