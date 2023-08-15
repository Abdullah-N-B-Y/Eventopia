using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IPaymentRepository
{
    List<Payment> GetAllPayments();
    Payment GetPaymentById(int id);
	bool PayForNewEvent(PaymentDetailsDTO paymentDetailsDTO);
	bool PayForEventRegister(PaymentDetailsDTO paymentDetailsDTO);
}
