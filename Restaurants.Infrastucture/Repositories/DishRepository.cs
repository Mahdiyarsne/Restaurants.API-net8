using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastucture.Persistence;

namespace Restaurants.Infrastucture.Repositories;

public class DishRepository(RestautantDbContext  dbContext) : IDishRepository
{
    public async Task<int> Create(Dish entity)
    {
        dbContext.Dishes.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity.Id;
    }
}
