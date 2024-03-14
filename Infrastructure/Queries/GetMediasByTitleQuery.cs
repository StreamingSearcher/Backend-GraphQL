

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class GetMediasByTitleQuery : IGetMediasByTitleQuery
    {
        private readonly MediaDbContext _context;

        public GetMediasByTitleQuery(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetMediasByTitle(string title)
        {
            return await _context.Movies.Where(m => m.Title.ToLower().Contains(title)).ToListAsync();
        }
    }
}
