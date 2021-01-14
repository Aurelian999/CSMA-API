using CSMA_API.Domain;
using System.Threading.Tasks;

namespace CSMA_API.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
