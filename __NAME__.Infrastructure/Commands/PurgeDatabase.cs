using Highway.Data.QueryObjects;

namespace __NAME__.Infrastructure.Commands
{
    public class PurgeDatabase : AdvancedCommand
    {
        public PurgeDatabase()
        {
            ContextQuery = context =>
                {
                    const string sql = @"-- disable all constraints
EXEC sp_msforeachtable ""ALTER TABLE ? NOCHECK CONSTRAINT all""

-- delete data in all tables
EXEC sp_MSForEachTable ""DELETE FROM ?""

-- enable all constraints
exec sp_msforeachtable ""ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all""

-- resets all seeds
exec sp_msforeachtable ""DBCC CHECKIDENT(? , RESEED, 0)""";
                    context.ExecuteSqlCommand(sql, null);
                };
        }
    }
}