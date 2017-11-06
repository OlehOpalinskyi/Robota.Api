using Robota.api.Contracts;
using System.Collections.Generic;
using System.Linq;
using Robota.api.Models;
using Robota.Data;
using static AutoMapper.Mapper;
using Robota.Data.Models;

namespace Robota.api.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly RobotaContext _dataContext;

        public CategoryRepo(RobotaContext dataContext)
        {
            _dataContext = dataContext;
        }
        public CategoryViewModel Create(CategoryViewModel category)
        {
            var dataCategory = Map<CategoryDataModel>(category);
            _dataContext.Categories.Add(dataCategory);
            _dataContext.SaveChanges();

            return Map<CategoryViewModel>(dataCategory);
        }

        public CategoryViewModel Delete(int id)
        {
            var category = _dataContext.Categories.Single(c => c.Id == id);
            _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();
            return Map<CategoryViewModel>(category);
        }

        public CategoryViewModel Edit(int id, string name)
        {
            var category = _dataContext.Categories.Single(c => c.Id == id);
            category.Name = name;
            _dataContext.SaveChanges();
            return Map<CategoryViewModel>(category);
        }

        public CategoryViewModel Get(int id)
        {
            var category = _dataContext.Categories.SingleOrDefault(c => c.Id == id);

            return Map<CategoryViewModel>(category);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = _dataContext.Categories.ToList();
            //_dataContext.Dispose();

            return Map<IEnumerable<CategoryViewModel>>(categories);
        }
    }
}