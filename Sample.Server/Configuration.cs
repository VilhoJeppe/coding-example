using Sample.Services;
using Topshelf;
using Topshelf.Ninject;

namespace Sample.Server
{
    internal static class Configuration
    {
        internal static void Configure()
        {
            HostFactory.Run(x =>
            {
                x.UseNinject(new IocModule());
                x.Service<PersistingSvc>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted((service, hostControl) => service.Start(hostControl));
                    s.WhenStopped((service, hostControl) => service.Stop(hostControl));
                   
                });
                //Setup Account that window service use to run.  
                x.RunAsLocalSystem();
                x.SetServiceName("PersistingSvc");
                x.SetDisplayName("Persisting service");
                x.SetDescription("A very fine service indeed");
                
            });
        }

    }
}
