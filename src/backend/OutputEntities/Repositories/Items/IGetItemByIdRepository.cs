using CoreEntities.Items;

namespace OutputPort.Repositories.Items;

public interface IGetItemByIdRepository
{
    Task<Item> Execute(int id);
}
