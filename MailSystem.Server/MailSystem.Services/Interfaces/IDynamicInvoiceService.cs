namespace MailSystem.Services.Interfaces
{
    public interface IDynamicInvoiceService
    {
        IInvoiceService GetServiceByConfiguration();
    }
}