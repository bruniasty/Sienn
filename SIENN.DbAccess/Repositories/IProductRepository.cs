using System.Collections.Generic;
using SIENN.DbAccess.DTO;

namespace SIENN.DbAccess.Repositories
{
    public interface IProductRepository<T> : IGenericRepository<T> where T : class
    {
        IEnumerable<ProductInfoDto> GetRangeInfo(int start, int count);
        IEnumerable<ProductDto> GetRange(int start, int count, bool isAvailable);
        IEnumerable<ProductDto> GetFiltered(string type = null, string category = null, string unit = null);
    }
}