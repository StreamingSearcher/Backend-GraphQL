
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetMediasByTitleService : IGetMediasByTitleService
    {
        private readonly IGetMediasByTitleQuery _query;

        public GetMediasByTitleService(IGetMediasByTitleQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Media>> GetMediasByTitle(string title)
        {
            return await _query.GetMediasByTitle(title);
        }
    }
}
