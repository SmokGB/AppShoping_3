using AppShoping.Entities;
namespace AppShoping.DataProviders.Extensions
{
    public static class PurchaseExtensions   
    {
        public static IEnumerable<PurchaseStatistics> OrderByNameAndPrice(IEnumerable<PurchaseStatistics> query)
        {

            return query.OrderBy(x => x.Price)
                        .ThenBy(x => x.Name);
                        
        }


    }
}
