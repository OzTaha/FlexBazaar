using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlexBazaar.Catalog.Dtos.BrandDtos
{
    public class GetByIdBrandDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
