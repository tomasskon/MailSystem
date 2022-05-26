using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        
        public ShipmentsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        
    }
}