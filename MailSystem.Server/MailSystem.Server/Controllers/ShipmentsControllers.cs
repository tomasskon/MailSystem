using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IInvoiceService _invoiceService;
        
        public ShipmentsController(IMapper mapper, IShipmentService shipmentService, IInvoiceService invoiceService)
        {
            _mapper = mapper;
            _shipmentService = shipmentService;
            _invoiceService = invoiceService;
        }

        /// <response code="404">UserNotFoundException, NoShipmentFoundException</response>
        [HttpGet]
        public async Task<IActionResult> GetUserShipments(Guid userId)
        {
            try
            {
                var shipments = await _shipmentService.GetUserShipments(userId);

                return Ok(_mapper.Map<List<ShipmentContract>>(shipments));
            }
            catch (NoShipmentsFoundException ex)
            {
                return NotFound(new StandardExceptionResponse(ex));
            }
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
        
        [HttpGet]
        public async Task<FileStreamResult> GetPdf([FromQuery] Guid shipmentId)
        {
            Response.Headers.Add("Content-Disposition", "attachment; filename=shipment.pdf;");
            return File(new MemoryStream(await _invoiceService.GenerateInvoice(shipmentId)), "application/octet-stream");
        }
    }
}