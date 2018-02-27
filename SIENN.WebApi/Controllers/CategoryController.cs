using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : SimpleCrudController<Category, ICategoryService<Category>>
    {
        public CategoryController(StoreDbContext dbContext, IMapper mapper, ICategoryService<Category> service) : base(service)
        {
        }
    }
}