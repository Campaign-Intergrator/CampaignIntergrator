using MediatR;

namespace CampaignIntergrator.App.Server.Interfaces.Requests
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
