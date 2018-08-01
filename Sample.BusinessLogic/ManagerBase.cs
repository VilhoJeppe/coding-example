using log4net;
using Sample.DatabaseEF;

namespace Sample.BusinessLogic
{
    public class ManagerBase
    {
        protected SampleDataContext DataContext;

        protected ManagerBase(SampleDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
