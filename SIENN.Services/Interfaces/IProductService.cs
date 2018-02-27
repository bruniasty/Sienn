using System.Collections.Generic;
using SIENN.DbAccess.DTO;

namespace SIENN.Services.Interfaces
{
    public interface IProductService<T> : IBaseCrudService<T> where T : class
    {
        List<ProductDto> GetAvailableProducts(int start, int count);
        List<T> GetProducts(int start, int count);
        List<ProductInfoDto> GetProductsInfo(int start, int count);
        List<ProductDto> GetFiltered(string type = null, string category = null, string unit = null);
    }
}