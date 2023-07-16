using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dBContext;

    public UserRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public List<User> GetAllUsers()
    {
        IEnumerable<User> users = _dBContext.Connection.Query<User>("User_Package.GetAllUsers", commandType:CommandType.StoredProcedure);
        return users.ToList();
    }
}
