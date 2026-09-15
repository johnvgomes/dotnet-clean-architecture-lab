using MediatR;
using Domain.Entities;

namespace Application.Products.Commands.CreateProduct;

// 1. O Envelope (Command): carrega os dados e define o retorno (Guid)
public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;

// 2. O Especialista (Handler): executa a regra de negócio quando recebe a carta
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Instancia a entidade rica do domínio (validações acontecem no construtor)
        var product = new Product(request.Name, request.Price);

        // Simulando persistência (no Dia 3 ligaremos o EF Core com PostgreSQL)
        await Task.CompletedTask;

        return product.Id;
    }
}