﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WeddingApp.Core.ApplicationService;
using WeddingApp.Entity;
using WeddingApp.Entity.Filters;

namespace WeddingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[Authorize(Roles = "Administrator")] // Get a list of all orders for admin // might require paging
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                    return Ok(_orderService.GetAllOrders(new Filter() { CurrentPage = 0, ItemsPerPage = 0 }));
            
                    //return Ok( _orderService.GetAllDates(1));
            

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize] // Get a list of singular orders.
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.ReadByID(id);
        }

        // Create order
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                if (id != order.ID)
                {
                    return BadRequest("Parameter ID and owner ID have to be the same");
                }

                return Ok(_orderService.EditOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_orderService.DeleteOrder(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}