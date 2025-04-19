namespace FlexBazaar.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectioString { get; set; }
        public string DatabaseName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
    }
}
