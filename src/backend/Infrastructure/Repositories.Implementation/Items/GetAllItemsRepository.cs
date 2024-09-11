using CoreEntities.Items;
using Dapper;
using OutputPort.Repositories.Items;
using System.Data;

namespace Infrastructure.Repositories.Implementation.Items;

public class GetAllItemsRepository(IDbConnection connection) : IGetAllItemsRepository
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<Item>> Execute()
    {
        return await _connection.QueryAsync<Item>(
            "SELECT [Id],[Name],[Date],[Description],[State] " +
            "FROM [dbo].[Item]");
    }
}
