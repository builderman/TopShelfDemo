using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfDemo
{
    public class MyService1
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
}
