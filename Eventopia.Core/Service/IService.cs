

namespace Eventopia.Core.Service;

public interface IService<T>
{
    bool CreateNew(T t);
    T GetById(int id);
    List<T> GetAll();
    bool Update(T t);
    bool Delete(int id);
}
