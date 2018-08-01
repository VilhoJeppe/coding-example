using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sample.DatabaseEF.Objects;

namespace Sample.DatabaseEF
{
    public class SampleDataContext : DbContext
    {
        public SampleDataContext()
            : base("name=DataContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<DeviceMovement> DeviceMovements { get; set; }

        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SampleDataContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(18, 6));
        }
    }
}
