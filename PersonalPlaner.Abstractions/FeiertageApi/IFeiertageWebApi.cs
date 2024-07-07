using PersonalPlaner.Shared.FeiertageApi;

namespace PersonalPlaner.Abstractions.FeiertageApi
{
    public interface IFeiertageWebApi
    {
        Task<FeiertageResponse> GetFeiertageAsync(DateTime year, FeiertageRequestOptions? options = null);
        
    }
}