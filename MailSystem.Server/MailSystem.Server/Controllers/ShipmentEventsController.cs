using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoMapper;
using MailSystem.Contracts;
using MailSystem.Contracts.ShipmentEvents;
using MailSystem.Exception;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShipmentEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShipmentEventService _shipmentEventService;
        
        public ShipmentEventsController(IMapper mapper, IShipmentEventService shipmentEventService)
        {
            _mapper = mapper;
            _shipmentEventService = shipmentEventService;
        }

        /// <response code="404">NoShipmentEventsFoundException</response>
        [HttpGet]
        public IActionResult GetEventsByTrackingId(string trackingId)
        {
            try
            {
                var shipmentEvents = _shipmentEventService.GetAllByTrackingId(trackingId);

                return Ok(_mapper.Map<List<DetailedShipmentEventContract>>(shipmentEvents));
            }
            catch (NoShipmentEventsFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
        }
    }
}