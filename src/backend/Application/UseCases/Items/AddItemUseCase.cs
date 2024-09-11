using CoreEntities.Items;
using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;

namespace Application.UseCases.Items;

public class AddItemUseCase(IAddItemRepository addItemRepository) : IAddItemUseCase
{
    private readonly IAddItemRepository _addItemRepository = addItemRepository;

    public async Task Handle(Item item)
    {
        await _addItemRepository.Execute(item);
    }
}