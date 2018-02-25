using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : SimpleCrudController<Category, int>
    {
        public CategoryController(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}