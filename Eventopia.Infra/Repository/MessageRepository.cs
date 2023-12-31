﻿using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class MessageRepository : IRepository<Message>
{
    private readonly IDbContext _dbContext;

    public MessageRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool CreateNew(Message message)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("p_Content", message.Content, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_MessageDate", message.MessageDate, dbType: DbType.Date, direction: ParameterDirection.Input);
        parameters.Add("p_IsRead", message.IsRead, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_IsDeleted", message.IsDeleted, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        parameters.Add("p_SenderId", message.SenderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_ReceiverId", message.ReceiverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        
        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Message_Package.CreateMessage", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public Message GetById(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_Id",id,dbType:DbType.Int32,direction:ParameterDirection.Input);

        return _dbContext.Connection.Query<Message>("Message_Package.GetMessageById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
    }

    public List<Message> GetAll()
    {
        return _dbContext.Connection.Query<Message>("Message_Package.GetAllMessages",commandType:CommandType.StoredProcedure).ToList();
    }

    public bool Update(Message message)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_Id", message.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_Content", message.Content, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_MessageDate", message.MessageDate, dbType: DbType.Date, direction: ParameterDirection.Input);
        parameters.Add("p_IsRead", message.IsRead, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_IsDeleted", message.IsDeleted, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_SenderId", message.SenderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_ReceiverId", message.ReceiverId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Booking_Package.UpdateBooking", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("p_IsSuccessed") == 1;
    }

    public bool Delete(int id)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_Id",id,dbType:DbType.Int32,direction:ParameterDirection.Input);

        parameters.Add("p_IsSuccessed", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _dbContext.Connection.Execute("Message_Package.DeleteMessage",parameters,commandType:CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsSuccessed") == 1;
    }
}
