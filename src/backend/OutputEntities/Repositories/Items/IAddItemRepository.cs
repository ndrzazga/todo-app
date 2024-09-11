using CoreEntities.Items;

namespace OutputPort.Repositories.Items;

public interface IAddItemRepository
{
    Task Execute(Item item);
}
