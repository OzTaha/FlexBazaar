using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlexBazaar.Catalog.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
