

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class CreateGenreCommand : ICreateGenreCommand
    {
        private readonly MediaDbContext _context;

        public CreateGenreCommand(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            await _context.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
