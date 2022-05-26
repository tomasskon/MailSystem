using System.Collections.Generic;
using AutoMapper;
using MailSystem.Contracts.ShipmentSizes;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShipmentSizesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShipmentSizeService _shipmentSizeService;

        public ShipmentSizesController(IMapper mapper, IShipmentSizeService shipmentSizeService)
        {
            _mapper = mapper;
            _shipmentSizeService = shipmentSizeService;
        }

        [HttpGet]
        public IActionResult GetShipmentSizes()
        {
            var shipmentSizes = _shipmentSizeService.GetAll();

            return Ok(_mapper.Map<List<ShipmentSizeContract>>(shipmentSizes));
        }
    }
}