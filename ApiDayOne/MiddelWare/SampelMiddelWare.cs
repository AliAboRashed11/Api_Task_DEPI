namespace ApiDayOne.MiddelWare
{
    public class SampelMiddelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SampelMiddelWare> _logger;
        public SampelMiddelWare(RequestDelegate next,ILogger<SampelMiddelWare> logger)
        {
            this._next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("SampelMiddelWare Start");
            _next(context);
            _logger.LogInformation("SampelMiddelWare End");

        }
    }
}
