using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfDemo
{
    public interface IService
    {
        void Start();
        void Stop();
    }
    public class MyService1 : IService
    {
        private readonly ILog _logger; // = LogManager.GetLogger("abc");
        public MyService1(ILog logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            _logger.Info("Start ---");
        }
        public void Stop()
        {
            _logger.Info("Stop ---");
        }

    }

    public class MyService2 : IService
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(MyService2));

        public void Start()
        {
            _logger.Info("Start ---");
        }
        public void Stop()
        {
            _logger.Info("Stop ---");
        }

    }

    public class MyService3 : IService
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(MyService3));

        private static IService _instance = new MyService3();
        public static IService Instance
        {
            get
            {
                return _instance;
            }
        }

        private MyService3()
        {

        }

        public void Start()
        {
            _logger.Info("Start ---");
        }
        public void Stop()
        {
            _logger.Info("Stop ---");
        }

    }


}
