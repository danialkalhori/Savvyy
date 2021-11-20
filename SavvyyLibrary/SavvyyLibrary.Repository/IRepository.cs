using SavvyyLibrary.Model.Model;

namespace SavvyyLibrary.Repository
{
    public interface IRepository
    {
        Task<int> Save<T>(T entity) where T : Entity;

        Task Delete<T>(T entity) where T : Entity;

        Task<T> Get<T>(int id) where T : Entity;

        Task<List<T>> GetList<T>(System.Linq.Expressions.Expression<Func<T, bool>> query) where T : Entity;
    }
}