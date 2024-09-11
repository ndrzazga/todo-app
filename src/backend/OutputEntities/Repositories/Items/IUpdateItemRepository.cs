using CoreEntities.Items;

namespace OutputPort.Repositories.Items;

public interface IUpdateItemRepository
{
    Task Execute(Item updatedItem);
}
