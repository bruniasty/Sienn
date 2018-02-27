namespace SIENN.Services.Interfaces
{
    public interface ICategoryService<T> : IBaseCrudService<T> where T : class
    {
    }
}