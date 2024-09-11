using CoreEntities.Items;

namespace InputPort.UseCases.Items;

public interface IUpdateItemUseCase
{
    Task Handle(Item updatedItem);
}