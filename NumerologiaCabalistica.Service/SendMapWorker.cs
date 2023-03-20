using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NumerologiaCabalistica.Repository;
using NumerologiaCabalistica.Service.Model;

namespace NumerologiaCabalistica.Service
{
    public class SendMapWorker : IHostedService
    {
        private Timer? _timer = null;
        private readonly ILogger<SendMapWorker> _logger;    
        public SendMapWorker(ILogger<SendMapWorker> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Timed Hosted Service Runnig {typeof(SendMapWorker)}");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Proccess finished {typeof(SendMapWorker)}");
            return Task.CompletedTask;

        }

        public async void DoWork(object state)
        {
            _logger.LogInformation("Time hosted service is working");

            try
            {
                CommandRepository repository = new CommandRepository();
                List<Customer> customers = new List<Customer>();
                customers = repository.GetCustomers();

                _logger.LogInformation($"{customers.Count} customers");
                
                foreach (Customer customer in customers)
                {
                    await APIService.SendAPI(customer);
                    if (customer.MapFile != null)
                    {
                        _logger.LogInformation(customer.MapFile.ToString());
                        bool enviado = ServiceMessenger.SendMail(customer);
                        if (enviado) repository.SaveBDSendMap(customer.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError($"***************Exception*********** => {ex.Message}");
                //Console.WriteLine(ex);
            }
        }
    }
}