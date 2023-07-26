using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepsitory;

    public PaymentService(IPaymentRepository paymentRepsitory)
    {
        _paymentRepsitory = paymentRepsitory;
    }
    public bool Pay(int eventId, Bank bank)
    {
        return _paymentRepsitory.Pay(eventId, bank);
    }
}
