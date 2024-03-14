using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace GraphQL
{
    public class Query
    {
        private readonly MovieDbContext _context;

        public Query(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Movie>> GetMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }
    }
}
