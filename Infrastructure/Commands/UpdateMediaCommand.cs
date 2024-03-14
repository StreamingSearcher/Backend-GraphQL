
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class UpdateMediaCommand : IUpdateMediaCommand
    {
        private readonly MediaDbContext _context;

        public UpdateMediaCommand(MediaDbContext context)
        {
            _context = context;
        }


        public async Task<Media> UpdateMedia(Media movie)
        {     
            movie.IsPlatformLoaded = true;
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
