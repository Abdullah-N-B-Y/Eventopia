using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Repository
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly IDbContext _dBContext;

        public ProfileRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Profile GetById(int id)
        {
           
            throw new NotImplementedException();
        }

        public List<Profile> GetAll()
        {
            IEnumerable<Profile> result = _dBContext.Connection.Query<Profile>("PROFILE_PACKAGE.GetAllProfiles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateNew(Profile profile)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            throw new NotImplementedException();
        }

        public void Update(Profile profile)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            
            throw new NotImplementedException();
        }
    }
}
