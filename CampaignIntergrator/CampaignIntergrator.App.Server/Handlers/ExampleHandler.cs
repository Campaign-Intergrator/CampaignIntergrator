using CampaignIntergrator.App.Server.Filters;
using CampaignIntergrator.App.Server.Middleware;
using CampaignIntergrator.App.Server.Requests;
using CampaignIntergrator.App.Server.Services;
using MediatR;

namespace CampaignIntergrator.App.Server.Handlers
{
    public class ExampleHandler(ILogger<ExampleHandler> logger, GuidService guidService) : IRequestHandler<ExampleRequest, IResult>
    {
        private readonly ILogger<ExampleHandler> _logger = logger;
        private readonly GuidService _guidService = guidService;
        public async Task<IResult> Handle(ExampleRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{count}", _guidService.Count);
            await Task.Delay(1);
            _guidService.Count++;
            _logger.LogInformation("{count}", _guidService.Count);
            return Results.Ok(new {message = _guidService.Count});
        }
    }
}
