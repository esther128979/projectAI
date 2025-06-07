using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using BL.Api;
using BL.Models;
using server.Models;
using AutoMapper;
using DAL.Services;

namespace server.Controllers
{
    [Route("DosFlix/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBL _bl;
        private readonly IMapper _mapper;

        public OrdersController(IBL bl, IMapper mapper)
        {
            _bl = bl;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _bl.Order.GetAll();
            return Ok(orders);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetByCustomerId(int id)
        {
            var orders = await _bl.Order.GetByIdCustomer(id);
            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO order)
        {
            var dtoOrder = _mapper.Map<BLOrder>(order);

            await _bl.Order.AddOrder(dtoOrder);
            return Ok("Order created and email links sent.");
        }
       


    }


}

