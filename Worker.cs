namespace MyWindowServiceApplication
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    File.AppendAllText("C:\\Test\\my_note.txt", "WelCome Dhananjay " + DateTime.Now.ToString()+ Environment.NewLine);
                }
                await Task.Delay(20*1000, stoppingToken);
            }
        }
    }
}
