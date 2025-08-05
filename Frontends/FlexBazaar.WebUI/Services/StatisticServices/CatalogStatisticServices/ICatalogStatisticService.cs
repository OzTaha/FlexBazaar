namespace FlexBazaar.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        // kategori sayısı
        Task<long> GetCategoryCount();
        // ürün sayısı
        Task<long> GetProductCount();
        // marka sayısı
        Task<long> GetBrandCount();
        // ortalama ürün fiyatı
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}

