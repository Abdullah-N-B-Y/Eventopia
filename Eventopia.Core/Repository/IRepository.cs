namespace Eventopia.Core.Repository;

public interface IRepository<T>
{
    void CreateNew(T t);
    T GetById(int id);
    List<T> GetAll();
    void Update(T t);
    void Delete(int id);
}
