using CoreEntities.Items;
using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;

namespace Application.UseCases.Items;

public class UpdateItemUseCase(IUpdateItemRepository updateItemRepository, IGetItemByIdUseCase getItemByIdUseCase) : IUpdateItemUseCase
{
    private readonly IUpdateItemRepository _updateItemRepository = updateItemRepository;
    private readonly IGetItemByIdUseCase _getItemByIdUseCase = getItemByIdUseCase;

    public async Task Handle(Item updatedItem)
    {
        await _getItemByIdUseCase.Handle(updatedItem.Id);
        await _updateItemRepository.Execute(updatedItem);
    }
}
