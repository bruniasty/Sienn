using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : SimpleCrudController<Type, int>
    {
        public TypeController(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}