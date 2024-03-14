
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUpdateMediaService
    {
        Task<Media> UpdateMedia(Media movie);
    }
}
