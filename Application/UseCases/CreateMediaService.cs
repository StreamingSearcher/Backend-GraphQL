
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class CreateMediaService : ICreateMediaService
    {
        private readonly ICreateMediaCommand _command;

        public CreateMediaService(ICreateMediaCommand command)
        {
            _command = command;
        }

        public async Task<Media> CreateMedia(Media movie)
        {
           return await _command.CreateMedia(movie);
        }
    }
}
