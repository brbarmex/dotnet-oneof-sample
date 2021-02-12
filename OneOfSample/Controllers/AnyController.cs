using System;
using Microsoft.AspNetCore.Mvc;
using OneOfSample.Models;
using OneOfSample.OneOfServices.Exceptions;
using OneOfSample.Services;

namespace OneOfSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnyController : ControllerBase
    {
        [HttpPost("v1/payments")]
        public IActionResult Post(OrderPurchase body)
        {
            try
            {
                var result = new TraditionalWay().MakePayment(body);

                if (result is null)
                    return BadRequest();

                return Ok(result);
            }
            catch (OrderPurchaseException ex)
            {
                return BadRequest(error: ex.Message);
            }
            catch(Exception ex)
            {
                // Any exception...
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("v2/payments")]
        public IActionResult UsingOneOf(OrderPurchase body)
        =>  new AnExoticForm()
            .MakePayment(body)
            .Match<IActionResult>
            (
                proofPayment => Ok(proofPayment),
                orderPaymentInvalid => BadRequest(orderPaymentInvalid.InvalidMessage)
            );
    }
}