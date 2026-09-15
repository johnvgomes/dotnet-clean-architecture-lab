using MediatR;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductById;

var builder = WebApplication.CreateBuilder(args);

// Suporte nativo a OpenAPI no .NET 10
builder.Services.AddOpenApi();

// Registra o MediatR buscando todos os Handlers da camada Application
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// POST: Apenas despacha o Command via MediatR (Controller/API ultra limpa!)
app.MapPost("/api/products", async (CreateProductCommand command, ISender sender) =>
{
    var productId = await sender.Send(command);
    return Results.Created($"/api/products/{productId}", new { id = productId });
});

// GET: Apenas despacha a Query via MediatR
app.MapGet("/api/products/{id:guid}", async (Guid id, ISender sender) =>
{
    var product = await sender.Send(new GetProductByIdQuery(id));
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.Run();