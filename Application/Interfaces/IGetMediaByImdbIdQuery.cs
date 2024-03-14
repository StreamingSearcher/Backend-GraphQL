
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGetMediaByImdbIdQuery
    {
        Task<Media> GetMediaByImdbId(string imdbId);
    }
}
