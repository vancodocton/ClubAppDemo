using Ardalis.Specification;

namespace ClubApp.Core.Interfaces
{
    public interface IReadRepository<T> : IDisposable, IReadRepositoryBase<T> where T : class
    {
    }
}
