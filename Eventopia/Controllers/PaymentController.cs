using Eventopia.Core.Data;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [Route("Pay/{eventId}")]
    public IActionResult Pay(int eventId, [FromBody] Bank bank)
    {
		_paymentService.Pay(eventId, bank);
        return Ok();
    }
}
