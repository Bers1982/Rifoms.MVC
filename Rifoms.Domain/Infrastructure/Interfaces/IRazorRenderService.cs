using System.Threading.Tasks;

namespace Rifoms.Domain.Infrastructure.Interfaces
{
    public interface IRazorRenderService
    {
        Task<string> ToStringAsync<T>(string viewName, T model);
    }
}
