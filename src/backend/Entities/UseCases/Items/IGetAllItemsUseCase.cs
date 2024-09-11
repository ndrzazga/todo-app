using CoreEntities.Items;

namespace InputPort.UseCases.Items;

public interface IGetAllItemsUseCase
{
    Task<IEnumerable<Item>> Handle();
}