using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Contracts;
using MailSystem.Contracts.Shipment;
using MailSystem.Domain.Models;
using MailSystem.Exception;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShipmentService _shipmentService;
        
        public ShipmentsController(IMapper mapper, IShipmentService shipmentService)
        {
            _mapper = mapper;
            _shipmentService = shipmentService;
        }

        /// <response code="404">UserNotFoundException, MailboxNotFoundException, ShipmentSizeNotFoundException</response>
        [HttpPost]
        public async Task<IActionResult> RegisterShipment([FromBody] RegisterShipmentContract registerShipmentContract)
        {
            try
            {
                var shipment = _mapper.Map<Shipment>(registerShipmentContract);
                
                return Ok(await _shipmentService.CreateShipment(shipment));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
            catch (MailboxNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
            catch (ShipmentSizeNotFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
        }
    }
}