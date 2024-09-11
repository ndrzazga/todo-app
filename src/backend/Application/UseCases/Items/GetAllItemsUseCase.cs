using CoreEntities.Items;
using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;

namespace Application.UseCases.Items;

public class GetAllItemsUseCase(IGetAllItemsRepository getAllItemsRepository) : IGetAllItemsUseCase
{
    private readonly IGetAllItemsRepository _getAllItemsRepository = getAllItemsRepository;

    public async Task<IEnumerable<Item>> Handle()
    {
        return await _getAllItemsRepository.Execute();
    }
}
