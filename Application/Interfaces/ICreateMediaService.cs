

using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateMediaService
    {
        Task<Media> CreateMedia(Media movie);
    }
}
