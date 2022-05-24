using System;
using System.Collections.Generic;
using AutoMapper;
using MailSystem.Contracts.Couriers;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CourierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourierService _courierService;

        public CourierController(IMapper mapper, ICourierService courierService)
        {
            _mapper = mapper;
            _courierService = courierService;
        }

        [HttpGet]
        public IActionResult GetCouriers()
        {
            var couriers = _courierService.GetAll();

            return Ok(_mapper.Map<List<CourierContract>>(couriers));
        }
        
        [HttpGet]
        public IActionResult GetCourier(Guid courierId)
        {
            try
            {
                var courier = _courierService.Get(courierId);

                return Ok(_mapper.Map<CourierContract>(courier));
            }
            catch (CourierNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCourier([FromBody] CreateCourierContract createCourierContract)
        {
            var courier = _mapper.Map<Courier>(createCourierContract);
            var courierId = _courierService.Create(courier);
            
            return Ok(courierId);
        }
        
        [HttpPut]
        public IActionResult UpdateCourier([FromBody] UpdateCourierContract updateCourierContract)
        {
            try
            {
                var courier = _mapper.Map<Courier>(updateCourierContract);
                _courierService.Update(courier);
                
                return Ok();

            }
            catch (CourierNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCourier(Guid courierId)
        {
            try
            {
                _courierService.Delete(courierId);
                
                return Ok();

            }
            catch (CourierNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}