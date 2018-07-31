using System.ServiceModel;

namespace Sample.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public class SampleClientSvc
    {
    }
}
