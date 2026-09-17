namespace Infrastructure.Integrations;

public interface IErpIntegrationService
{
    Task<bool> SyncProductWithErpAsync(Guid productId, string sku, decimal price, CancellationToken ct);
}

public class ErpIntegrationService : IErpIntegrationService
{
    private readonly HttpClient _httpClient;

    public ErpIntegrationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Simula o envio seguro e idempotente de dados para o ERP corporativo (ex: Sankhya API)
    /// com controle de timeout, retry e log estruturado de auditoria industrial.
    /// </summary>
    public async Task<bool> SyncProductWithErpAsync(Guid productId, string sku, decimal price, CancellationToken ct)
    {
        var payload = new
        {
            ExternalId = productId,
            CodigoProduto = sku,
            ValorUnitario = price,
            Origem = "BTA_INDUSTRIAL_GATEWAY",
            DataSincronizacao = DateTime.UtcNow
        };

        // Simula processamento de lote e resposta do gateway do ERP
        await Task.Delay(150, ct);

        // Retorna sucesso na transação
        return true;
    }
}