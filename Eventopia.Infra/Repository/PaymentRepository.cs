using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
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

    public bool Pay(int eventId, Bank bank)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("p_EventId", eventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        parameters.Add("p_CardNumber", bank.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_CardHolder", bank.Cardholder, dbType: DbType.String, direction: ParameterDirection.Input);
        parameters.Add("p_ExpirationDate", bank.Expirationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        parameters.Add("p_CVV", bank.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);

        parameters.Add("p_IsPaid", dbType: DbType.Int32, direction: ParameterDirection.Output);

        int numberOfAffectedColumns = _dbContext.Connection.Execute("Payment_Package.Pay", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("p_IsPaid") == 1;

    }
}
