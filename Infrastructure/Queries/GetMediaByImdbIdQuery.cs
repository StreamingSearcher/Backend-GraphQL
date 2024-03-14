

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class GetMediaByImdbIdQuery : IGetMediaByImdbIdQuery
    {
        private readonly MediaDbContext _context;

        public GetMediaByImdbIdQuery(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<Media> GetMediaByImdbId(string imdbId)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.ImdbId == imdbId);
        }
    }
}
