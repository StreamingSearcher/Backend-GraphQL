
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class CreateCountryService : ICreateCountryService
    {
        private readonly ICreateCountryCommand _command;

        public CreateCountryService(ICreateCountryCommand command)
        {
            _command = command;
        }

        public async Task<Country> CreateCountry(Country country)
        {
            return await _command.CreateCountry(country);
        }
    }
}
