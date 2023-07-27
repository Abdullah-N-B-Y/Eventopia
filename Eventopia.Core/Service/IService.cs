

namespace Eventopia.Core.Service;

public interface IService<T>
{
    void CreateNew(T t);
    T GetById(int id);
    List<T> GetAll();
    void Update(T t);
    void Delete(int id);
}
