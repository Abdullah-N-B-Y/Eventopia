using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Service;

public interface IPaymentService
{
	List<Payment> GetAllPayments();
	Payment GetPaymentById(int id);
	bool PayForNewEvent(PaymentDetailsDTO paymentDetailsDTO);
	bool PayForEventRegister(PaymentDetailsDTO paymentDetailsDTO);
}
