
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateGenreService
    {
        Task<Genre> CreateGenre(Genre genre);
    }
}
