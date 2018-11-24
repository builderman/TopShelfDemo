using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.log4net;
using Topshelf;
using log4net;
using log4net.Config;
using System.IO;

namespace TopShelfDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var container = CreateContainer();

            var exitCode =  HostFactory.Run(hostConfigurator=> {
                hostConfigurator.UseLog4Net();
                hostConfigurator.SetDescription("This is a description");
                hostConfigurator.SetDisplayName("DisplayName");
                hostConfigurator.SetServiceName("ServiceName");

                hostConfigurator.Service<MyService1>(serviceConfigurator=> {
                    serviceConfigurator.ConstructUsing(p => container.Resolve<MyService1>());
                    serviceConfigurator.WhenStarted(p => p.Start());
                    serviceConfigurator.WhenStopped(p => p.Stop());
                }).RunAsLocalSystem();
            });
        }

        public static IUnityContainer CreateContainer()
        {
            XmlConfigurator.Configure(new FileInfo("Log4Net.config"));

            var container = new UnityContainer();
            container.AddNewExtension<Log4NetExtension>();
            container.RegisterSingleton<MyService1>();

            return container;
        }



    }
}
