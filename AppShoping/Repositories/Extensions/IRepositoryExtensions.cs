using AppShoping.Entities;

namespace AppShoping.Repositories.Extensions;

public interface IRepositoryExtensions
{
    void ExportFoodListToJsonFiles<T>(IRepository<T> repository) where T : class, IEntity;
    void ImportFoodListFromJson<T>(IRepository<T> repository) where T : class, IEntity;
    void WriteAllToConsole(IReadRepository<IEntity> allFoods);

}
