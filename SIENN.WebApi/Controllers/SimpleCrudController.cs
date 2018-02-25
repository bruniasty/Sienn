using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Repositories;
using SIENN.Services;

namespace SIENN.WebApi.Controllers
{
    public class SimpleCrudController<T, TKey> : Controller
        where T : class
        where TKey : IEquatable<TKey>
    {
        protected readonly ISimpleCrudService<T, TKey> crudService;

        public SimpleCrudController(StoreDbContext dbContext)
        {
            this.crudService = new SimpleCrudService<T, TKey>(dbContext);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<object> List()
        {
            return await this.crudService.List();
        }

        [HttpGet]
        public async Task<object> Get(TKey id)
        {
            try
            {
                return await this.crudService.Get(id);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<object> Update([FromBody] T model)
        {
            try
            {
                await this.crudService.Update(model);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<object> Create([FromBody] T model)
        {
            try
            {
                await this.crudService.Create(model);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<object> Delete(TKey id)
        {
            try
            {
                await this.crudService.Delete(id);
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }

            return "SUCCESS";
        }
    }
}