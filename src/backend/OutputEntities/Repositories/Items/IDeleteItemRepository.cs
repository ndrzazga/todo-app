namespace OutputPort.Repositories.Items;

public interface IDeleteItemRepository
{
    Task Execute(int id);
}
