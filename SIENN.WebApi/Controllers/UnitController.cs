using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : SimpleCrudController<Unit, IUnitService<Unit>>
    {
        public UnitController(StoreDbContext dbContext, IMapper mapper, IUnitService<Unit> service) : base(service)
        {
        }
    }
}