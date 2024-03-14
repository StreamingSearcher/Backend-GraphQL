using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateCountryService
    {
        Task<Country> CreateCountry(Country country);
    }
}
