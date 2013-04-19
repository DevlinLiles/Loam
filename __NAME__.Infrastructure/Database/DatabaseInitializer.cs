using System.Data.Entity;
using Common.Logging;
using Common.Logging.Simple;
using Highway.Data;

namespace __NAME__.Infrastructure.Database
{
    // Remove the obsolete attribute once you've addressed this change.
    // TODO Change the base class for this to an Initializer that matches your strategy.
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        public ILog Logger { get; set; }

        public DatabaseInitializer() 
        {
            Logger = new NoOpLogger();
        }

        protected override void Seed(DataContext context)
        {
            Logger.Info("Seeding Database");
            base.Seed(context);
        }
    }
}
