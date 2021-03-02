using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using AutomobileClassification.Core.Application.Common.Interface;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Exceptions;
using AutomobileClassification.Core.Domain.Entities;

namespace WebApi.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesModelsController : ControllerBase
    {
        private readonly ICategoryModelService _service;
        public CategoriesModelsController(ICategoryModelService service)
        {
            _service = service;
        }

        // POST: api/categorymodels
        [Route("/api/categories/create")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory(Category entity)
        {
            return await _service.CreateCategory(entity);
        }

        [Route("/api/models/create")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateModel(Model entity)
        {
            return await _service.CreateModel(entity);
        }
    }
}