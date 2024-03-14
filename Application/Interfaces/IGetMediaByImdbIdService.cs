
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGetMediaByImdbIdService
    {
        Task<Media> GetMediaByImdbId(string imdbId);
    }
}
