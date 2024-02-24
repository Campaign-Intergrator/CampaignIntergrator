
namespace CampaignIntergrator.App.Server.Middleware
{
    public class ValidationMappingMiddleware(ILogger<ValidationMappingMiddleware> logger) : IMiddleware
    {
		private readonly ILogger<ValidationMappingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
                _logger.LogInformation("Starting Validation of Middleware");
                await next(context);
                _logger.LogInformation("Completed Validation of Middleware");
            }
			catch (Exception ex)
			{
				_logger.LogInformation("{Exception}", ex.Message);
				throw;
			}
        }
    }
}
