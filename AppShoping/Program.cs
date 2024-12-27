using AppShoping.App;
using AppShoping.Data;
using AppShoping.DataProviders;
using AppShoping.Entities;
using AppShoping.Menu;
using AppShoping.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton <IRepository<Food>,SqlRepository<Food>>();
services.AddSingleton<IRepository<BioFood>,SqlRepository<BioFood>>(); 
services.AddSingleton<IRepository<PurchaseStatistics>,SqlRepository<PurchaseStatistics>>();
services.AddSingleton<IPurchaseProvider,PurchaseProvider>();

services.AddDbContext<ShopAppDbContext>(options =>options.UseInMemoryDatabase("StorageAppDb"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();


if (app == null)
{
     throw new InvalidOperationException("Nie udało się uzyskać instancji IApp.");
}
app.Run();