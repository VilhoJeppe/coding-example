using Ninject.Modules;
using Sample.BusinessLogic;
using Sample.BusinessLogicInterface.Interface;
using Sample.DatabaseEF;

namespace Sample.Server
{
    public class IocModule: NinjectModule
        {
        public override void Load()
        {
            Bind<IMovementManager>().To<MovementManager>();
            Bind<SampleDataContext>().ToSelf();
        }
    }
}
