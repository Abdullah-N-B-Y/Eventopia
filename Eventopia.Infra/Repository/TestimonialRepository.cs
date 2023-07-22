using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Eventopia.Infra.Repository
{
    public class TestimonialRepository : IRepository<Testimonial>
    {
        private readonly IDbContext _dBContext;

        public TestimonialRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void CreateNew(Testimonial testimonial)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CONTENT", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("CREATIONDATE", testimonial.Creationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("USERID", testimonial.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.CreateTestimonial", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("TESTIMONIAL_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.DeleteTestimonialByID", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(decimal id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetAll()
        {
            IEnumerable<Testimonial> result = _dBContext.Connection.Query<Testimonial>("TESTIMONIAL_PACKAGE.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("TESTIMONIAL_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result = _dBContext.Connection.Query<Testimonial>("TESTIMONIAL_PACKAGE.GetTestimonialByID", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Testimonial GetById(decimal id)
        {
            throw new NotImplementedException();
        }

        public void Update(Testimonial testimonial)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TESTIMONIAL_ID", testimonial.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("CONTENT", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("CREATIONDATE", testimonial.Creationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("USERID", testimonial.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.UpdateTestimonialByID", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
