

using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class CreateGenreService : ICreateGenreService
    {
        private readonly ICreateGenreCommand _command;

        public CreateGenreService(ICreateGenreCommand command)
        {
            _command = command;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            return await _command.CreateGenre(genre);
        }
    }
}
