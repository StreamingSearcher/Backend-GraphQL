

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUpdateMediaCommand
    {
        Task<Media> UpdateMedia(Media movie);
    }
}
