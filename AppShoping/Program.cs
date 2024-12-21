using AppShoping.App;
using AppShoping.Data;
using AppShoping.DataProviders;
using AppShoping.Entities;
using AppShoping.Menu;
using AppShoping.Repositories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IRepository<Food>>(provider => new SqlRepository<Food>(new ShopAppDbContext()));
services.AddSingleton<IRepository<BioFood>>(provider => new SqlRepository<BioFood>(new ShopAppDbContext()));
services.AddSingleton<IRepository<PurchaseStatistics>>(provider => new SqlRepository<PurchaseStatistics>(new ShopAppDbContext()));
services.AddSingleton<IPurchaseProvider,PurchaseProvider>();
    


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

if (app == null)
{
     throw new InvalidOperationException("Nie udało się uzyskać instancji IApp.");
}

app.Run();