using CampaignIntergrator.App.Server.Interfaces.Requests;

namespace CampaignIntergrator.App.Server.Requests;

public class ExampleRequest : IHttpRequest
{
    public required int Age {  get; init; }
    public required string Name { get; init; }
}
