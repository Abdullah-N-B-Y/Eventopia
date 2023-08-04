using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class TestimonialRepository : IRepository<Testimonial>
{
    private readonly IDbContext _dBContext;

    public TestimonialRepository(IDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public bool CreateNew(Testimonial testimonial)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_Content", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_CreationDate", testimonial.CreationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", testimonial.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.CreateTestimonial", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
        var parameters = new DynamicParameters();

        parameters.Add("p_TestimonialID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.DeleteTestimonialByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
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

    public bool Update(Testimonial testimonial)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_TestimonialID", testimonial.Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_Content", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_CreationDate", testimonial.CreationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_UserID", testimonial.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.UpdateTestimonialByID", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}
