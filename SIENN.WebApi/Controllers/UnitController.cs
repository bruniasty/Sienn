﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : SimpleCrudController<Unit>
    {
        public UnitController(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}