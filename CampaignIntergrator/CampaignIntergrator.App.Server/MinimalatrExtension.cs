using CampaignIntergrator.App.Server.Interfaces.Requests;
using MediatR;

namespace CampaignIntergrator.App.Server;

public static class MinimalatrExtension
{
    public static RouteHandlerBuilder MediateGet<TRequest>(this WebApplication app, string template) where TRequest: IHttpRequest
    {
        return app.MapGet(template, async (
            IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
    }
}
