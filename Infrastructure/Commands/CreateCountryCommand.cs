
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class CreateCountryCommand : ICreateCountryCommand
    {
        private readonly MediaDbContext _context;

        public CreateCountryCommand(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateCountry(Country country)
        {
            await _context.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }
    }
}
