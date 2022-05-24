using System.Threading.Tasks;

namespace MailSystem.Client.Interfaces
{
    public interface ILocalStorageService
    {
        Task<string> GetItem(string key);
        Task SetItem(string key, string value);
        Task RemoveItem(string key);
    }
}