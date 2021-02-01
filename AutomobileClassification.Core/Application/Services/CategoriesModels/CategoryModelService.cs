using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomobileClassification.Core.Application.Services.CategoriesModels
{
    public class CategoryModelService : ICategoryModelService
    {
        private readonly IAppDbContext _context;
        public CategoryModelService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(Category entity)
        {
            entity.Id = 0;
            entity.Slug = SlugHelper.Create(true, entity.Title);
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CreateModel(Model entity)
        {
            entity.Id = 0;
            entity.Url = SlugHelper.Create(true, entity.Title);
            _context.Models.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        
        public Task<List<Category>> GetCategories()
        {
            return _context.Categories.OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }

        public Task<List<Model>> GetModels()
        {
            return _context.Models.OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }
    }
}    