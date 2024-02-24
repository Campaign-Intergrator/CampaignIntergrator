using Microsoft.AspNetCore.Components;

namespace CampaignIntergrator.App.Client.Pages;

public partial class Home
{
    [Inject]
    public required HttpClient http_client { get; init; }

    protected override async Task OnInitializedAsync()
    {
        string response = await http_client.GetStringAsync("/");
        _ = response;
    }
}