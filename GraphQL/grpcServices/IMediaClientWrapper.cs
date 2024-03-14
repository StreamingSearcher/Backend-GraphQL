using RelationalMicroservice;

namespace GraphQL.grpcServices
{
    public interface IMediaClientWrapper 
    {
        Task<ApiTitleListProto> GetMediaByTitle(string title);
        Task<ApiIdProto> GetMediaById(string id);
        Task<GenresResponseProto> GetAllGenres();
        Task<CountriesResponseProto> GetAllCountries();
    }
}
