using MediatR;

namespace Application.Products.Queries.GetProductById;

// DTO de resposta leve (não expõe a entidade de banco diretamente)
public record ProductDto(Guid Id, string Name, decimal Price, bool IsActive);

// A Requisição de Consulta (Query)
public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

// O Handler da Consulta
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // Mock rápido de retorno enquanto conectamos o banco no Dia 3
        await Task.CompletedTask;

        return new ProductDto(
            request.Id, 
            "Produto Exemplo CQRS", 
            199.90m, 
            true
        );
    }
}