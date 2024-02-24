
using CampaignIntergrator.App.Server.Services;

namespace CampaignIntergrator.App.Server.Filters;

public class MetadataEndpointFilter(ILogger<MetadataEndpointFilter> logger, GuidService guidService) : IEndpointFilter
{
    private readonly ILogger<MetadataEndpointFilter> _logger = logger;
    private readonly GuidService _guidService = guidService;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        _logger.LogInformation("Starting Endpoint filter {count}", _guidService.Count);        
        object? response =  await next(context);
        _guidService.Count++;
        _logger.LogInformation("Completing Endpoint Filter {count}", _guidService.Count);
        return response;
    }
}
