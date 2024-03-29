using CampaignIntergrator.App.Server;
using CampaignIntergrator.App.Server.Filters;
using CampaignIntergrator.App.Server.Middleware;
using CampaignIntergrator.App.Server.Requests;
using CampaignIntergrator.App.Server.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options
    => options.AddDefaultPolicy(builder
    => builder.SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<ValidationMappingMiddleware>();
builder.Services.AddScoped<GuidService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseMiddleware<ValidationMappingMiddleware>();

app.MapGet("/", () =>
{
    return "HelloWorld";
})
.WithName("/")
.WithOpenApi()
.AddEndpointFilter<MetadataEndpointFilter>();

app.MediateGet<ExampleRequest>("example/{name}").AddEndpointFilter<MetadataEndpointFilter>();

app.Run();
