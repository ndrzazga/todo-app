using CoreEntities.Items;
using InputPort.UseCases.Items;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class ItemsEndpoints
{
    public static void MapItemsEndpoints(this WebApplication app)
    {
        // GET Items
        app.MapGet("/Items", async (IGetAllItemsUseCase getAllItemsUseCase) =>
        {
            var result = await getAllItemsUseCase.Handle();
            return Results.Ok(result);
        });

        // GET Items/{id}
        app.MapGet("/Items/{id:int}", async (int id, IGetItemByIdUseCase getByIdItemUseCase) =>
        {
            var result = await getByIdItemUseCase.Handle(id);
            return Results.Ok(result);
        });

        // POST Items
        app.MapPost("/Items", async (Item item, IAddItemUseCase addItemUseCase) =>
        {
            await addItemUseCase.Handle(item);
            return Results.Ok();
        });

        // PUT Items
        app.MapPut("/Items/{id:int}", async (int id, Item updatedItem, IUpdateItemUseCase updateItemUseCase) =>
        {
            await updateItemUseCase.Handle(updatedItem);
            return Results.Ok();
        });

        // DELETE Items/{id}
        app.MapDelete("/Items/{id:int}", async (int id, IDeleteItemUseCase deleteItemUseCase) =>
        {
            await deleteItemUseCase.Handle(id);
            return Results.Ok();
        });
    }
}