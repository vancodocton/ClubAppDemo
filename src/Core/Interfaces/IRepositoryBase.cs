using Ardalis.Specification;

namespace ClubApp.Core.Interfaces
{
    public interface IRepository<T> : IDisposable, IRepositoryBase<T> where T : class
    {
    }
}
