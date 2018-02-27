using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : SimpleCrudController<Type, ITypeService<Type>>
    {
        public TypeController(StoreDbContext dbContext, IMapper mapper, ITypeService<Type> service) : base(service)
        {
        }
    }
}