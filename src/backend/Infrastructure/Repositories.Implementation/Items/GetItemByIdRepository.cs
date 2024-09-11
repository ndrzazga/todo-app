using CoreEntities.Items;
using Dapper;
using OutputPort.Repositories.Items;
using System.Data;

namespace Infrastructure.Repositories.Implementation.Items;

public class GetItemByIdRepository(IDbConnection connection) : IGetItemByIdRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<Item> Execute(int id)
    {
        return await _connection.QuerySingleOrDefaultAsync<Item>(
            "SELECT [Id],[Name],[Date],[Description],[State] " +
            "FROM [dbo].[Item] " +
            "WHERE Id = @id",
        new
        {
            id
        });
    }
}
