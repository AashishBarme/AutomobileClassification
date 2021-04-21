using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Exceptions;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutomobileClassification.Core.Application.Services.CategoriesModels
{
    public class CategoryModelService : ICategoryModelService
    {
        private readonly AppDbContext _context;
        public CategoryModelService(AppDbContext context)
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


        public async Task<Category> GetCategory(string title)
        {
            var url = SlugHelper.Create(true, title); 
            var entity =  await _context.Categories.Where(x => x.Slug == url).FirstOrDefaultAsync();
            if(entity == null)
            {
                throw new NotFoundException();
            }
            return entity;

        }

         public string GetCategoryById(int id)
        {
            var entity =   _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if(entity == null)
            {
                throw new NotFoundException();
            }
            return entity.Slug;

        }

        public Task<List<Category>> GetCategories()
        {
            return _context.Categories.OrderByDescending(x => x.Id)
            .AsNoTracking().ToListAsync();
        }

        public Task<List<Model>> GetModels()
        {
            return _context.Models.OrderByDescending(x => x.Id)
            .AsNoTracking().ToListAsync();
        }

    }
}    