using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [Route("PayForNewEvent")]
    public IActionResult PayForNewEvent([FromBody] PaymentDetailsDTO paymentDetailsDTO)
    {
		bool isSuccess = _paymentService.PayForNewEvent(paymentDetailsDTO);
		if (!isSuccess)
		{
			return BadRequest(new { error = "payment failed" });
		}
		return Ok();
    }

	[HttpPost]
	[Route("PayForEventRegister")]
	public IActionResult PayForEventRegister([FromBody] PaymentDetailsDTO paymentDetailsDTO)
	{
		bool isSuccess = _paymentService.PayForEventRegister(paymentDetailsDTO);
		if(!isSuccess)
		{
			return BadRequest(new { error = "payment failed"});
		}
		return Ok();
	}

	[HttpGet]
	[Route("GetAllPayments")]
	public List<Payment> GetAllPayments()
	{
		return _paymentService.GetAllPayments();
	}

	[HttpGet]
	[Route("GetPaymentById/{id}")]
	public IActionResult GetPaymentById(
		[Required(ErrorMessage = "PaymentId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "PaymentId must be a positive number.")]
		int id)
	{
		Payment payment = _paymentService.GetPaymentById(id);
		if (payment == null)
			return NotFound();

		return Ok(payment);
	}
}
