using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShipmentEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        
        public ShipmentEventsController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}