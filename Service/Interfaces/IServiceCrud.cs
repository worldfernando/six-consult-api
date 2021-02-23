namespace SixConsultApi.Service.Interfaces
{
    public interface IServiceCrud<T>
    {
        T GetById(int id);
        void BeforeDelete(T objectInstance);
        T Delete(T objectInstance);
        void AfterDelete(T objectInstance);
        void BeforePost(T objectInstance);
        T Post(T objectInstance);
        void AfterPost(T objectInstance);
        void BeforeUpdate(T objectInstance);
        T Update(T objectInstance);
        void AfterUpdate(T objectInstance);
    }
}