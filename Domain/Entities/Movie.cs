

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Title { get; set; }
        public string? ImdbId { get; set; }
        public string? Overview { get; set; }
        public string? ImageUrl { get; set; }
        public int? TitleType { get; set; }
        public int? Year { get; set; }
        public required Boolean Status { get; set; }
        public required Boolean IsPlatformLoaded { get; set; }
        public IList<string>? Genres { get; set; }
        public IList<CountryPlatform>? CountryPlatforms { get; set; }
    }
}
