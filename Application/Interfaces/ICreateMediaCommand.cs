
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateMediaCommand
    {
        Task<Media> CreateMedia(Media movie);
    }
}
