using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;

namespace Application.UseCases.Items;

public class DeleteItemUseCase(IDeleteItemRepository deleteItemRepository, IGetItemByIdUseCase getItemByIdUseCase) : IDeleteItemUseCase
{
    private readonly IDeleteItemRepository _deleteItemRepository = deleteItemRepository;
    private readonly IGetItemByIdUseCase _getItemByIdUseCase = getItemByIdUseCase;

    public async Task Handle(int id)
    {
        await _getItemByIdUseCase.Handle(id);
        await _deleteItemRepository.Execute(id);
    }
}
