
using Eventopia.Core.Data;
using Microsoft.Extensions.Logging;
using System;

namespace Eventopia.Core.Repository;
public interface IPaymentRepository
{
    bool Pay(int eventId, Bank bank);

}
