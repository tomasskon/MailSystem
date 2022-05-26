using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.Mailboxes;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class MailboxHttpClient : IMailboxHttpClient
    {
        private readonly IAuthorizedHttpClient _authorizedHttpClient;

        public MailboxHttpClient(IAuthorizedHttpClient authorizedHttpClient)
        {
            _authorizedHttpClient = authorizedHttpClient;
        }
        
        public async Task<IEnumerable<MailboxContract>> GetMailboxes()
        {
            using var client = await _authorizedHttpClient.CreateHttpClient();
            var response = await client.GetAsync("Mailboxes/GetMailboxes");

            return await _authorizedHttpClient.HandleResponse<IEnumerable<MailboxContract>>(response);
        }
    }
}