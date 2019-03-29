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
            //TODO:
            XmlConfigurator.Configure(new FileInfo("Log4Net.config"));

            //var container = CreateContainer();
            //IServer service = container.Resolve<IServer>();

            //IServer service = new MyService2();

            IService service = MyService3.Instance;

            var exitCode =  HostFactory.Run(hostConfigurator=> {
                hostConfigurator.UseLog4Net();
                hostConfigurator.SetDescription("This is a description");
                hostConfigurator.SetDisplayName("DisplayName");
                hostConfigurator.SetServiceName("ServiceName");

                hostConfigurator.Service<IService>(serviceConfigurator=> {
                    serviceConfigurator.ConstructUsing(p => service);
                    serviceConfigurator.WhenStarted(p => p.Start());
                    serviceConfigurator.WhenStopped(p => p.Stop());
                }).RunAsLocalSystem();
            });
        }

        public static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.AddNewExtension<Log4NetExtension>();
            container.RegisterSingleton(typeof(IService), typeof(MyService1));
            //container.RegisterSingleton(typeof(IServer), typeof(MyService2), "2");

            return container;
        }



    }
}
