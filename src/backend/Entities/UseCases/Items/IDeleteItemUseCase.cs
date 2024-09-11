namespace InputPort.UseCases.Items;

public interface IDeleteItemUseCase
{
    Task Handle(int id);
}