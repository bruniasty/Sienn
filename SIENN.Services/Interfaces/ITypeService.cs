namespace SIENN.Services.Interfaces
{
    public interface ITypeService<T> : IBaseCrudService<T> where T : class
    {
    }
}