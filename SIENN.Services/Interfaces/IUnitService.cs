namespace SIENN.Services.Interfaces
{
    public interface IUnitService<T> : IBaseCrudService<T> where T : class
    {
    }
}