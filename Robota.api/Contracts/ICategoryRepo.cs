using Robota.api.Models;
using System.Collections.Generic;

namespace Robota.api.Contracts
{
    public interface ICategoryRepo
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel Get(int id);
        CategoryViewModel Create(CategoryViewModel category);
        CategoryViewModel Edit(int id, string name);
        CategoryViewModel Delete(int id);
    }
}
