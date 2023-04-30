using Marrubium.Web.Models;

namespace Marrubium.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
