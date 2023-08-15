using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using System.Data;

namespace Eventopia.Infra.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbContext _dbContext;

    public PaymentRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

	public List<Payment> GetAllPayments()
	{
		return _dbContext.Connection.Query<Payment>("Payment_Package.GetAllPayments", commandType: CommandType.StoredProcedure).ToList();
	}

	public Payment GetPaymentById(int id)
	{
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_PaymentId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

		var result = _dbContext.Connection.Query<Payment>("Payment_Package.GetPaymentById", parameters, commandType: CommandType.StoredProcedure);

		return result.FirstOrDefault();
	}

	public bool PayForEventRegister(PaymentDetailsDTO paymentDetailsDTO)
	{
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_UserId", paymentDetailsDTO.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_EventId", paymentDetailsDTO.EventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_PaymentAmount", paymentDetailsDTO.PaymentAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_CardNumber", paymentDetailsDTO.Bank?.CardNumber, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_CardHolder", paymentDetailsDTO.Bank?.CardHolder, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ExpirationDate", paymentDetailsDTO.Bank?.ExpirationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_CVV", paymentDetailsDTO.Bank?.CVV, dbType: DbType.String, direction: ParameterDirection.Input);

		parameters.Add("p_IsPaid", dbType: DbType.Int32, direction: ParameterDirection.Output);

		int numberOfAffectedColumns = _dbContext.Connection.Execute("Payment_Package.PayForEventRegister", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_IsPaid") == 1;
	}

	public bool PayForNewEvent(PaymentDetailsDTO paymentDetailsDTO)
	{
		DynamicParameters parameters = new DynamicParameters();

		parameters.Add("p_UserId", paymentDetailsDTO.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_EventId", paymentDetailsDTO.EventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
		parameters.Add("p_PaymentAmount", paymentDetailsDTO.PaymentAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
		parameters.Add("p_CardNumber", paymentDetailsDTO.Bank?.CardNumber, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_CardHolder", paymentDetailsDTO.Bank?.CardHolder, dbType: DbType.String, direction: ParameterDirection.Input);
		parameters.Add("p_ExpirationDate", paymentDetailsDTO.Bank?.ExpirationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
		parameters.Add("p_CVV", paymentDetailsDTO.Bank?.CVV, dbType: DbType.String, direction: ParameterDirection.Input);

		parameters.Add("p_IsPaid", dbType: DbType.Int32, direction: ParameterDirection.Output);

		int numberOfAffectedColumns = _dbContext.Connection.Execute("Payment_Package.PayForNewEvent", parameters, commandType: CommandType.StoredProcedure);

		return parameters.Get<int>("p_IsPaid") == 1;
	}
}
