using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Contracts.Mailboxes;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class MailboxesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMailboxService _mailboxService;

        public MailboxesController(IMapper mapper, IMailboxService mailboxService)
        {
            _mapper = mapper;
            _mailboxService = mailboxService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMailboxes()
        {
            var mailboxes = await _mailboxService.GetAll();

            return Ok(_mapper.Map<List<MailboxContract>>(mailboxes));
        }
    }
}