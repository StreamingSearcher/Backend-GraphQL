
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class UpdateMediaService : IUpdateMediaService
    {
        private readonly IUpdateMediaCommand _command;

        public UpdateMediaService(IUpdateMediaCommand command)
        {
            _command = command;
        }

        public async Task<Media> UpdateMedia(Media movie)
        {
            return await _command.UpdateMedia(movie);
        }
    }
}
