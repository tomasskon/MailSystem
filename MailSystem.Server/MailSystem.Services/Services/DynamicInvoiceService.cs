using System;
using MailSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailSystem.Services.Services
{
    public class DynamicInvoiceService : IDynamicInvoiceService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly bool _isLithuanian;
        
        public DynamicInvoiceService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _isLithuanian  = bool.Parse(configuration.GetSection("InvoiceGenerator")["IsLithuanian"]);
        }
        
        public IInvoiceService GetServiceByConfiguration()
        {
            if (_isLithuanian) 
                return _serviceProvider.GetService<InvoiceServiceLithuanian>();
            
            return _serviceProvider.GetService<InvoiceService>();
        }

    }
}