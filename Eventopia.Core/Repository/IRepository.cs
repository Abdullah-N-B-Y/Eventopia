

using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IRepository<T>
{
    void CreateNew(T t);

}
