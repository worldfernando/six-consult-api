using System.Linq;

namespace SixConsultApi.Service.Interfaces
{
    public interface IServiceCrud<T>
    {
        IQueryable<T> Query(string filter);
        T GetById(int id);
        T Delete(T objectInstance);
        T Post(T objectInstance);
        T Update(T objectInstance);
    }
}   