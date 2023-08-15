using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Utility;

namespace Eventopia.Infra.Service;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepsitory;
	private readonly IUserRepository _userRepository;
	private readonly IEventRepository _eventRepository;

	public PaymentService(IPaymentRepository paymentRepsitory, IUserRepository userRepository, IEventRepository eventRepository)
	{
		_paymentRepsitory = paymentRepsitory;
		_userRepository = userRepository;
		_eventRepository = eventRepository;
	}

	public List<Payment> GetAllPayments()
	{
		return _paymentRepsitory.GetAllPayments();
	}

	public Payment GetPaymentById(int id)
	{
		return _paymentRepsitory.GetPaymentById(id);
	}

	public bool PayForEventRegister(PaymentDetailsDTO paymentDetailsDTO)
	{
		bool isSuccess = _paymentRepsitory.PayForEventRegister(paymentDetailsDTO);
		if (isSuccess)
		{
			User u = _userRepository.GetById((int)paymentDetailsDTO.UserId);
			Event e = _eventRepository.GetById((int)paymentDetailsDTO.EventId);
			DateTime d = DateTime.Now;
			string pdfBody =
$@"=====================================================
                    INVOICE
=====================================================
Date: {d.Month}/{d.Day}/{d.Year}

Bill To:
{u.Username}
Email: {u.Email}

Event Details:
Event Name: {e.Name}
Event Date: {e.StartDate.Value.Month}/{e.StartDate.Value.Day}/{e.StartDate.Value.Year} - {e.EndDate.Value.Month}/{e.EndDate.Value.Day}/{e.EndDate.Value.Year}
Location: {e.Address}

-----------------------------------------------------

Description                                    Amount
-----------------------------------------------------
Event Ticket                                  ${e.AttendingCost}
-----------------------------------------------------

Thank you for choosing Eventopia!

=====================================================";

			string subject = "Event registration invoice";
			string body = "Invoice in pdf form";
			string pdfSubject = "Invoice";
			string toEmail = u.Email;
			EmailUtility.SendEmailWithPDFAsync(subject, body, pdfSubject, pdfBody, toEmail);
			return true;
		}
		return false;
	}

	public bool PayForNewEvent(PaymentDetailsDTO paymentDetailsDTO)
	{
		bool isSuccess = _paymentRepsitory.PayForNewEvent(paymentDetailsDTO);
		if (isSuccess)
		{
			User u = _userRepository.GetById((int)paymentDetailsDTO.UserId);
			Event e = _eventRepository.GetById((int)paymentDetailsDTO.EventId);
			DateTime d = DateTime.Now;
			string pdfBody =
$@"=====================================================
                    INVOICE
=====================================================
Date: {d.Month}/{d.Day}/{d.Year}

Bill To:
{u.Username}
Email: {u.Email}

Event Details:
Event Name: {e.Name}
Event Date: {e.StartDate.Value.Month}/{e.StartDate.Value.Day}/{e.StartDate.Value.Year} - {e.EndDate.Value.Month}/{e.EndDate.Value.Day}/{e.EndDate.Value.Year}
Location: {e.Address}

-----------------------------------------------------

Description                                    Amount
-----------------------------------------------------
Event Created                                  ${e.AttendingCost}
-----------------------------------------------------

Thank you for choosing Eventopia!

=====================================================";
			string subject = "Event creation invoice";
			string body = "Invoice in pdf form";
			string pdfSubject = "Invoice";
			string toEmail = u.Email;
			EmailUtility.SendEmailWithPDFAsync(subject, body, pdfSubject, pdfBody, toEmail);
			return true;
		}
		return false;
	}
}
