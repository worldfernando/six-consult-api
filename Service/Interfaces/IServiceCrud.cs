namespace SixConsultApi.Service.Interfaces
{
    public interface IServiceCrud<T>
    {
        T GetById(int id);
        T Delete(T objectInstance);
        T Post(T objectInstance);
        T Update(T objectInstance);
    }
}