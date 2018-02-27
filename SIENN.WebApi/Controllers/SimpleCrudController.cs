using System;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Interfaces;

namespace SIENN.WebApi.Controllers
{
    public class SimpleCrudController<TEntity, TService> : Controller where TEntity : class
                                                                      where TService : IBaseCrudService<TEntity>
    {
        protected readonly TService Service;

        public SimpleCrudController(TService service)
        {
            this.Service = service;
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
        public object Update([FromBody] TEntity model)
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
        public object Create([FromBody] TEntity model)
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