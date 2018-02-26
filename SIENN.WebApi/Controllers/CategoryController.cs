using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : SimpleCrudController<Category>
    {
        public CategoryController(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}