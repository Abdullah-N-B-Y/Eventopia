using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IPaymentRepository
{
    bool Pay(int eventId, Bank bank);
}
