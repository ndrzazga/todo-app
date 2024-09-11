using CoreEntities.Items;

namespace OutputPort.Repositories.Items;

public interface IGetAllItemsRepository
{
    Task<IEnumerable<Item>> Execute();
}
