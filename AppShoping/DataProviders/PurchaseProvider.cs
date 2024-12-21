using AppShoping.DataProviders.Extensions;
using AppShoping.Entities;
using AppShoping.Repositories;

namespace AppShoping.DataProviders;
public class PurchaseProvider : IPurchaseProvider
{

    private readonly IRepository<PurchaseStatistics> _purchaseRepository;
    public PurchaseProvider(IRepository<PurchaseStatistics> purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
        var products = GenerateSampleStatistics();
        foreach (var product in products)
            _purchaseRepository.Add(product);
        _purchaseRepository.Save();
    }


    private List<PurchaseStatistics> GetPurchasedProducts()
    {
        var products = _purchaseRepository.GetAll();
        var list = new List<PurchaseStatistics>();
        foreach (var product in products)
            list.Add(product);
        return list;

    }

    private static List<PurchaseStatistics> GenerateSampleStatistics()
    {
        return new List<PurchaseStatistics>
        {
            new PurchaseStatistics { Id=1, Name="Jabłka", Price= 5.45M, BioFood = false, NameShop = "Auchan", Promotion = false },
            new PurchaseStatistics { Id=2, Name="Jabłka", Price= 4.28M , BioFood = false, NameShop = "Auchan", Promotion = false },
            new PurchaseStatistics { Id=3, Name="Jabłka", Price= 3.45M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=4, Name="Jabłka", Price= 3.45M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=5, Name="Jabłka", Price= 5.25M, BioFood = true, NameShop = "Lidl", Promotion = true },
            new PurchaseStatistics { Id=6, Name="Jabłka", Price= 6.00M, BioFood = true, NameShop = "Biedronka", Promotion = false },
            new PurchaseStatistics { Id=7, Name="Jabłka", Price= 4.15M, BioFood = true, NameShop = "Auchan", Promotion = true },
            new PurchaseStatistics { Id=8, Name="Jabłka", Price= 7.20M, BioFood = true, NameShop = "Lidl", Promotion = false },
            new PurchaseStatistics { Id=9, Name="Marchew", Price= 3.85M, BioFood = true, NameShop = "Auchan", Promotion = false },
            new PurchaseStatistics { Id=10, Name="Marchew", Price= 5.20M, BioFood = true, NameShop = "Auchan", Promotion = false },
            new PurchaseStatistics { Id=11, Name="Awokado", Price= 8.45M, BioFood = false, NameShop = "Auchan", Promotion = false },
            new PurchaseStatistics { Id=12, Name="Banan", Price= 7.80M, BioFood = false, NameShop = "Lidl", Promotion = false },
            new PurchaseStatistics { Id=13, Name="Pomarancza", Price= 6.80M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=14, Name="Mango", Price= 8.95M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=15, Name="Mango", Price= 10.99M, BioFood = false, NameShop = "Lidl", Promotion = false },
            new PurchaseStatistics { Id=16, Name="Pomarancza", Price= 12M, BioFood = false, NameShop = "Żabka", Promotion = false },
            new PurchaseStatistics { Id=17, Name="Banan", Price= 2.99M, BioFood = false, NameShop = "Auchan", Promotion = true },
            new PurchaseStatistics { Id=18, Name="Maslo", Price= 8.25M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=19, Name="Mleko", Price= 2.89M, BioFood = false, NameShop = "Biedronka", Promotion = true },
            new PurchaseStatistics { Id=20, Name="Mleko", Price= 3.69M, BioFood = false, NameShop = "Lidl", Promotion = false }
        };
    }


    public List<string?> GetUniqueProduct()
    {

        var purchasedProducts = _purchaseRepository.GetAll();
        var uniqueProductName = purchasedProducts
            .Select(x => x.Name)
            .Distinct()
            .OrderBy(name => name)
            .ToList();
        return uniqueProductName;
    }

    public void GetMinPurchasedProductPrice()
    {
        var purchasedProducts = _purchaseRepository.GetAll().ToList();
        var minProduct = purchasedProducts
            .OrderBy(x => x.Price)
            .FirstOrDefault();
        if (minProduct != null)
        {
            Console.WriteLine($"{minProduct.Name}, Cena: {minProduct.Price:C}");
        }
    }

    public void GetMaxPriceOfAllPurchasedProducts()
    {
        var purchasedProducts = _purchaseRepository.GetAll().ToList();
        var maxProduct = purchasedProducts
            .OrderByDescending(x => x.Price)
            .FirstOrDefault();
        if (maxProduct != null)
        {
            Console.WriteLine($"{maxProduct.Name}, Cena: {maxProduct.Price:C}");
        }

    }
    public List<PurchaseStatistics> GetSpecificProductinTheShop()
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        var list = purchasedProduct.Select(product => new PurchaseStatistics
        {
            Id = product.Id,
            Name = product.Name,
            NameShop = product.NameShop,
        }).ToList();
        return list;
    }

    public List<PurchaseStatistics> OrderByName()
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct.OrderBy(x => x.Name).ToList();
    }

    public List<PurchaseStatistics> OrderProductByNameShopAndPrice()
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct
            .OrderBy(x => x.NameShop)
            .ThenBy(x => x.Name)
            .ThenBy(x => x.Price)
            .ToList();
    }

    public List<PurchaseStatistics> WherePriceIsGraterThan(decimal cost)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct.Where(x => x.Price > cost).ToList();
    }

    public List<PurchaseStatistics> WhereNameShopIsAndPromotionIs(string nameShop, bool promotion)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct.Where(x => x.NameShop == nameShop && x.Promotion == promotion).ToList();
    }

    public List<PurchaseStatistics> OrderByNameAndPrice()
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct
           .OrderBy(x => x.Price)
           .ThenBy(x => x.Name)
           .ToList();
    }


    public PurchaseStatistics FirstOrDefaultByPriceWithDefault(decimal price)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct.FirstOrDefault(
            x => x.Price == price) ?? new PurchaseStatistics { Id = -1, Name = "Brak produktu" };
    }


    public List<PurchaseStatistics> TakeProduct(Range range)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct
            .OrderBy(x => x.Id)
            .Take(range)
            .ToList();
    }

    public List<PurchaseStatistics> SkipProduct(int howMany)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct
            .OrderBy(x => x.Id)
            .Skip(howMany)
            .ToList();
    }

    public List<PurchaseStatistics> DistinctByName()
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct
            .DistinctBy(x => x.Name)
            .OrderBy(x => x.Id)
            .ToList();
    }

    public List<PurchaseStatistics[]> ChunkProduct(int size)
    {
        var purchasedProduct = _purchaseRepository.GetAll();
        return purchasedProduct.Chunk(size).ToList();
    }

    public int GetProducts()
    {
        return _purchaseRepository.GetAll().Count();
    }

    public List<PurchaseStatistics> GetProductsList()
    {
        return _purchaseRepository.GetAll().ToList();
    }
}