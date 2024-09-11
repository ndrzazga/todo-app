using CoreEntities.Items;

namespace InputPort.UseCases.Items;

public interface IAddItemUseCase
{
    Task Handle(Item item);
}
