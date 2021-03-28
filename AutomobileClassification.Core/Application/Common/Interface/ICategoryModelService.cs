using System.Collections.Generic;
using System.Threading.Tasks;
using AutomobileClassification.Core.Domain.Entities;

namespace AutomobileClassification.Core.Application.Common.Interface
{
    public interface ICategoryModelService
    {
         Task<int> CreateCategory(Category entity);
         Task<int> CreateModel(Model entity);
         Task<List<Category>> GetCategories();
         Task<List<Model>> GetModels();
        string GetCategoryById(int id);
    }
}