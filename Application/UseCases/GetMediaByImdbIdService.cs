

using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetMediaByImdbIdService : IGetMediaByImdbIdService
    {
        private readonly IGetMediaByImdbIdQuery _query;

        public GetMediaByImdbIdService(IGetMediaByImdbIdQuery query)
        {
            _query = query;
        }

        public async Task<Media> GetMediaByImdbId(string imdbId)
        {
            return await _query.GetMediaByImdbId(imdbId);
        }
    }
}
