using System.Data.Entity;

namespace Sample.DatabaseEF
{
    public class SampleDataContextInitializer : DropCreateDatabaseAlways<SampleDataContext>
    {
        protected override void Seed(SampleDataContext context)
        {
            base.Seed(context);
        }
    }
}
