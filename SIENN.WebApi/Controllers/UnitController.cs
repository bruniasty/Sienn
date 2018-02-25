using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : SimpleCrudController<Unit, int>
    {
        public UnitController(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}