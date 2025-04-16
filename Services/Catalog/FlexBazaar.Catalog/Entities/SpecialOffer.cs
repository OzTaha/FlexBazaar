using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlexBazaar.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
