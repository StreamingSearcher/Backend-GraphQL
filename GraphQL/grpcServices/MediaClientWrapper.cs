using Grpc.Net.Client;
using RelationalMicroservice;

namespace GraphQL.grpcServices
{
    public class MediaClientWrapper : IMediaClientWrapper
    {
        public readonly Media.MediaClient _client;

        public MediaClientWrapper(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new Media.MediaClient(channel);
        }


        public async Task<ApiTitleListProto> GetMediaByTitle(string title)
        {
            var grpcCall = await _client.GetMediaByTitleAsync(new MediaTitleProto { Title = title });
            return grpcCall;
        }

        public async Task<ApiIdProto> GetMediaById(string id)
        {
            var grpcCall = await _client.GetMediaByIdAsync(new MediaIdProto { Id = id });
            return grpcCall;
        }

        public async Task<GenresResponseProto> GetAllGenres()
        {
            var grpcCall = await _client.GetAllGenresAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return grpcCall;
        }

        public async Task<CountriesResponseProto> GetAllCountries()
        {
            var grpcCall = await _client.GetAllCountriesAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return grpcCall;
        }
    }
}
