namespace ApiDayOne.MiddelWare
{
    public class DataMiddelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DataMiddelWare> _logger;

        public DataMiddelWare(RequestDelegate next, ILogger<DataMiddelWare> logger) 
        {
            this._next = next;
            _logger = logger;

        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("DataMiddelWare Start");

            _next(context);
            _logger.LogInformation("DataMiddelWare End");

        }
    }
}
