using AppShoping.Entities;

namespace AppShoping.DataProviders;

public interface IPurchaseProvider
{
    public List<string?>? GetUniqueProduct();
    public List<PurchaseStatistics> GetProductsList();
    public void GetMinPurchasedProductPrice();
    public void GetMaxPriceOfAllPurchasedProducts();
    public List<PurchaseStatistics> OrderProductByNameShopAndPrice();
    public List<PurchaseStatistics> OrderByName();
    public PurchaseStatistics FirstOrDefaultByPriceWithDefault(decimal price);
    public List<PurchaseStatistics> WhereNameShopIsAndPromotionIs(string nameShop, bool promotion);
    public List<PurchaseStatistics> TakeProduct(Range range);
    public List<PurchaseStatistics> SkipProduct(int howMany);
    public List<PurchaseStatistics> DistinctByName();
    public List<PurchaseStatistics[]> ChunkProduct(int size);

}