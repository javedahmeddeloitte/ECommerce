using FulfilmentService.Business.Interface;
using FulfilmentService.CQRS.Command;
using FulfilmentService.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FulfilmentService.API.Controllers
{
    [ApiController]
    [Route("api/fulfillment")]
    public class FulFillmentController : ControllerBase
    {
        private readonly IFulfillmentCommandService _fulfillmentCommandService;
        public FulFillmentController(IFulfillmentCommandService fulfillmentCommandService)
        {
            _fulfillmentCommandService = fulfillmentCommandService;
        }
        [HttpPost("orderFulfillment")]
        public async Task<IActionResult> OrderFulfilmentAsync([FromBody] OrderFulfillmentCommand cmd)
        {
            var response = await _fulfillmentCommandService.OrderFulfilmentAsync(cmd);
            return Ok(response);
        }
    }
}
