using System.Data.Entity.Migrations;
using Highway.Data;

namespace __NAME__.Infrastructure.Database
{
    public class MigrationConfiguration :DbMigrationsConfiguration<DataContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsNamespace = "__Name__.Infrastructure.Database.Migrations";
        }
    }
}