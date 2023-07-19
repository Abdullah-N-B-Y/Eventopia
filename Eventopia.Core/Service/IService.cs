
namespace Eventopia.Core.Service;

public interface IService<T>
{
    void CreateNew(T t);
}
