
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGetMediasByTitleQuery
    {
        Task<IEnumerable<Media>> GetMediasByTitle(string title);
    }
}
