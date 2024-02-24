namespace CampaignIntergrator.App.Server.Services;

public class GuidService
{
    public Guid Id { get; init; }
    public DateTime UTCDatetime { get; init; }

    public int Count { get; set; }

    public GuidService() { 
        Id = Guid.NewGuid(); 
        UTCDatetime = DateTime.UtcNow;
        Count = 0;
    }

}
