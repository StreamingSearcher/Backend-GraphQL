

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Domain.Entities
{
    public class Country
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
