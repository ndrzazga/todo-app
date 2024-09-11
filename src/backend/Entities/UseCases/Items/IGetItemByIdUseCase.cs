using CoreEntities.Items;

namespace InputPort.UseCases.Items;

public interface IGetItemByIdUseCase
{
    Task<Item> Handle(int id);
}