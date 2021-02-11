using Microsoft.AspNetCore.Mvc;
using OneOfSample.OneOfServices;
using OneOfSample.OneOfServices.Exceptions;
using OneOfSample.OneOfServices.Models;

namespace OneOfSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnyController : ControllerBase
    {
        [HttpPost("traditional")]
        public IActionResult TraditionalPost(OrderPayment body)
        {
            try
            {
                var handlerResult = new PaymentService().MakePaymentUsingTraditionalMethod(body);

                if (handlerResult is null)
                    return BadRequest();

                return Ok(handlerResult);
            }
            catch (OrderPaymentException ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

        [HttpPost("one-of")]
        public IActionResult UsingOneOf(OrderPayment body)
        {
            return new PaymentService()
            .MakePaymentWitOneOf(body)
            .Match<IActionResult>
            (
                success => Ok(success),
                invalid => BadRequest(invalid.InvalidMessage)
            );
        }
    }
}