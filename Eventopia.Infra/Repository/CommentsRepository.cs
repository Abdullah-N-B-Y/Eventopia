using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;


namespace Eventopia.Infra.Repository;

public class CommentsRepository : ICommentsRepository
{
	private readonly IDbContext _dBContext;

	public CommentsRepository(IDbContext dBContext)
	{
		_dBContext = dBContext;
	}

	public bool CreateNew(Comment comment)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_Content", comment.Content, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("Event_Id", comment.EventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("User_Id", comment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("Comments_Package.CreateNewComment", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

	public bool Delete(int id)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

		parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

		_dBContext.Connection.Execute("Comments_Package.DeleteComment", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_IsSuccessed") == 1;
	}

	public List<Comment> GetAll()
	{
		return _dBContext.Connection.Query<Comment>("Comments_Package.GetAllComments", commandType: CommandType.StoredProcedure).ToList();
	}

	public Comment GetById(int id)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

		var result = _dBContext.Connection.Query<Comment>("Comments_Package.GetById", parameters, commandType: CommandType.StoredProcedure);
		return result.FirstOrDefault();
	}

	public List<Comment> GetEventComments(int eventId)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("Event_Id", eventId, dbType: DbType.Int32, direction: ParameterDirection.Input);

		return _dBContext.Connection.Query<Comment>("Comments_Package.GetByEventId", parameters, commandType: CommandType.StoredProcedure).ToList();
	}

	public List<Comment> GetUserComments(int userId)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("User_Id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

		return _dBContext.Connection.Query<Comment>("Comments_Package.GetByUserId", parameters, commandType: CommandType.StoredProcedure).ToList();
	}

	public List<Comment> GetUserCommentsOnEvent(int eventId, int userId)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("Event_Id", eventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("User_Id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

		return _dBContext.Connection.Query<Comment>("Comments_Package.GetByEventAndUserId", parameters, commandType: CommandType.StoredProcedure).ToList();
	}

	public bool Update(Comment comment)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("p_ID", comment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_Content", comment.Content, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("Event_Id", comment.EventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("User_Id", comment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dBContext.Connection.Execute("Comments_Package.UpdateComment", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}
