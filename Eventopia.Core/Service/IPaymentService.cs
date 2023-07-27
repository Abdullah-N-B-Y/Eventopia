using Eventopia.Core.Data;

namespace Eventopia.Core.Service;

public interface IPaymentService
{
    bool Pay(int eventId, Bank bank);
}
