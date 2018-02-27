using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.Services;

namespace SIENN.WebApi.Controllers
{
    public class SimpleCrudController<T> : Controller where T : class
    {
        protected readonly ISimpleCrudService<T> Service;

        public SimpleCrudController(StoreDbContext dbContext, IMapper mapper)
        {
            this.Service = new SimpleCrudService<T>(dbContext, mapper);
        }

        [HttpGet]
        [Route("[action]")]
        public object GetAll()
        {
            return this.Service.GetAll();
        }

        [HttpGet]
        public object Get(int id)
        {
            try
            {
                return this.Service.Get(id);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public object Update([FromBody] T model)
        {
            try
            {
                this.Service.Update(model);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpPost]
        [Route("[action]")]
        public object Create([FromBody] T model)
        {
            try
            {
                this.Service.Create(model);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpDelete]
        [Route("[action]")]
        public object Delete(int id)
        {
            try
            {
                this.Service.Delete(id);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }
    }
}