using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateCountryCommand
    {
        Task<Country> CreateCountry(Country country);
    }
}
