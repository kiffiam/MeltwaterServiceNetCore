using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeltwaterServiceNetCore;
using MeltwaterServiceNetCore.Entities;
using MeltwaterServiceNetCore.Services.Interfaces;

namespace MeltwaterServiceNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBookOrderService _bookOrderService;

        public OrdersController(IBookOrderService bookOrderService)
        {
            _bookOrderService = bookOrderService;

        }

        // GET: api/Orders
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders([FromRoute] long customerId)
        {
            var result = await _bookOrderService.GetOrders(customerId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<long>> PostOrder(long id, List<long> bookIds)
        {
            var result = await _bookOrderService.AddOrder(id, bookIds);
            return result;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] long? id)
        {
            var result = await _bookOrderService.DeleteOrder(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
