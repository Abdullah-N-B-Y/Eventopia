using System.Data.Common;


namespace Eventopia.Core.Common
{
        public interface IDbContext
        {
            public DbConnection Connection { get; }
        }
    
}
