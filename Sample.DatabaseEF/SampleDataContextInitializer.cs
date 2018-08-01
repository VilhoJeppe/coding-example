using System.Data.Entity;

namespace Sample.DatabaseEF
{
    //Only used in the beginning of project phase
    public class SampleDataContextInitializer : DropCreateDatabaseAlways<SampleDataContext>
    {
        protected override void Seed(SampleDataContext context)
        {
            base.Seed(context);
        }
    }
}
