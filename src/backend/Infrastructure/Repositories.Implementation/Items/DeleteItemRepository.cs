using Dapper;
using OutputPort.Repositories.Items;
using System.Data;

namespace Infrastructure.Repositories.Implementation.Items;

public class DeleteItemRepository(IDbConnection connection) : IDeleteItemRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task Execute(int id)
    {
        await _connection.ExecuteAsync(
            "DELETE FROM [dbo].[Item] " +
            "WHERE Id = @id",
        new
        {
            id
        });
    }
}
