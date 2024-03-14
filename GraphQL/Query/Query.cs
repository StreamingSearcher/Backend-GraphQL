using Application.Interfaces;
using Domain.Entities;
using GraphQL.grpcServices;
 
namespace GraphQL.Query
{
    public class Query
    {
        private readonly IMediaClientWrapper _mediaClient;
        private readonly ICreateMediaService _createMediaService;
        private readonly IGetMediasByTitleService _getMediasByTitleService;
        private readonly IGetMediaByImdbIdService _getMediaByImdbIdService;
        private readonly IUpdateMediaService _updateMediaService;

        public Query(IMediaClientWrapper mediaClient, 
                     ICreateMediaService createMediaService, 
                     IGetMediasByTitleService getMediasByTitleService, 
                     IGetMediaByImdbIdService getMediaByImdbIdService,
                     IUpdateMediaService updateMediaService
                     )
        {
            _mediaClient = mediaClient;
            _createMediaService = createMediaService;
            _getMediasByTitleService = getMediasByTitleService;
            _getMediaByImdbIdService = getMediaByImdbIdService;
            _updateMediaService = updateMediaService;
        }

        public async Task<IList<Media>> GetMoviesByTitleAsync(string title)
        {
            var moviesInMongo = await _getMediasByTitleService.GetMediasByTitle(title.ToLower());

            if (moviesInMongo.Count() > 0)
                return moviesInMongo.ToList();

            var moviesApi = await _mediaClient.GetMediaByTitle(title.ToLower());

            IList<Media> movies = new List<Media>();

            foreach (var movie in moviesApi.Results)
            {
                Media movieToSave = new Media()
                {
                    ImdbId = movie.Id,
                    ImageUrl = movie.Image.Url,
                    Title = movie.Title,
                    Year = movie.Year,
                    TitleType = movie.TitleType,
                    IsPlatformLoaded = false,
                    Status = false,
                    Genres = null,
                    CountryPlatforms = new List<CountryPlatform>()
                };

                movies.Add(movieToSave);
                await _createMediaService.CreateMedia(movieToSave);
            }

            return movies;
        }

        public async Task<Media> GetMoviesByIdAsync(string imdbId)
        {
            // Suponiendo que existen la peliculas/serie en la base de datos de mongo
            var movieInMongo = await _getMediaByImdbIdService.GetMediaByImdbId(imdbId);


            if (movieInMongo != null && movieInMongo.IsPlatformLoaded)
                return movieInMongo;

            var movieApi = await _mediaClient.GetMediaById(imdbId);

            movieInMongo.Overview = movieApi.Overview;
            movieInMongo.Genres = movieApi.Genres.Select(g => g.Name).ToArray();
            movieInMongo.CountryPlatforms = movieApi.StreamingInfo.Select(c => new CountryPlatform
            {
                Code = c.Key,
                Platforms = c.Value.Platforms.Select(p => p.Service).ToArray(),
            }).ToList();

            return await _updateMediaService.UpdateMedia(movieInMongo);
        }
    }
}
