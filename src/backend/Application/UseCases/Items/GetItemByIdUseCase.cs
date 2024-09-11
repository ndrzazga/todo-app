using Application.Exceptions;
using CoreEntities.Items;
using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;

namespace Application.UseCases.Items;

public class GetItemByIdUseCase(IGetItemByIdRepository getItemByIdRepository) : IGetItemByIdUseCase
{
    private readonly IGetItemByIdRepository _getItemByIdRepository = getItemByIdRepository;

    public async Task<Item> Handle(int id)
    {
        var item = await _getItemByIdRepository.Execute(id);
        return item == default ? throw new ItemNotFoundException(id) : item;
    }
}
