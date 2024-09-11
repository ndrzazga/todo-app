using CoreEntities.Items;
using Dapper;
using OutputPort.Repositories.Items;
using System.Data;

namespace Infrastructure.Repositories.Implementation.Items;

public class AddItemRepository(IDbConnection connection) : IAddItemRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task Execute(Item item)
    {
        await _connection.ExecuteAsync(
            "INSERT INTO [dbo].[Item] " +
            "VALUES (@Name, @Date, @Description, @State)",
        new
        {
            item.Name,
            item.Date,
            item.Description,
            item.State
        });
    }
}
