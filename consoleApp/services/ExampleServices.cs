using Microsoft.Extensions.Logging;

namespace console.services
{
    public interface IBaseService
    {
        void DoThing(int number);
    }

    public interface IExampleService
    {
        void DoSomeRealWork();
    }
    public class ExampleService : IExampleService
    {
        private readonly IBaseService _baseService;
        public ExampleService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public void DoSomeRealWork()
        {
            for (int i = 0; i < 10; i++)
            {
                _baseService.DoThing(i);
            }
        }
    }

    public class BaseService : IBaseService
    {
        private readonly ILogger<BaseService> _logger;
        public BaseService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BaseService>();
        }

        public void DoThing(int count)
        {
            try
            {
                _logger.LogInformation($"blah blah blah {count}");
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);                
            }
        }
    }
}