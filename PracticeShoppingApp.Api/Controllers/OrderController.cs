using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeShoppingApp.Application.Features.Orders.Commands;
using PracticeShoppingApp.Application.Features.Orders.Dtos;
using PracticeShoppingApp.Application.Features.Orders.Queries;

namespace PracticeShoppingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [Authorize(Roles = "admin,user")]
        [HttpGet("getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthDto>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthRequest = new GetOrdersForMonthRequest() { Date = date, Page = page, Size = size };
            var pagedOrdersForMonth = await _mediator.Send(getOrdersForMonthRequest);
            if (pagedOrdersForMonth == null)
                return NotFound();
            return Ok(pagedOrdersForMonth);
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateOrderResponse>> CreateOrder(CreateOrderRequest orderRequest)
        {
            var requestResponse = await _mediator.Send(orderRequest);
            if (requestResponse.ValidationErrors.Any())
            {
                if (requestResponse.ValidationErrors.Contains("No Product Found"))
                {
                    return NotFound();
                }
                if (requestResponse.ValidationErrors.Contains("No sufficient quantity"))
                {
                    return BadRequest("No Sufficient Quantity");
                }
            }
            return Ok(requestResponse);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteOrderRequest = new DeleteOrderRequest() { OrderId = id };
            await _mediator.Send(deleteOrderRequest);
            return Ok();
        }
    }
}
