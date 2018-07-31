using log4net;
using Sample.DatabaseEF;

namespace Sample.BusinessLogic
{
    public class ManagerBase
    {
        protected ILog Log { get; }

        protected SampleDataContext DataContext;

        protected ManagerBase(SampleDataContext dataContext) => DataContext = dataContext;
    }
}
