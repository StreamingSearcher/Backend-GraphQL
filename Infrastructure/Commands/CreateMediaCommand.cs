

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class CreateMediaCommand : ICreateMediaCommand
    {
        private readonly MediaDbContext _context;

        public CreateMediaCommand(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<Media> CreateMedia(Media movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
