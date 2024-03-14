

using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateGenreCommand
    {
        Task<Genre> CreateGenre(Genre genre);
    }
}
