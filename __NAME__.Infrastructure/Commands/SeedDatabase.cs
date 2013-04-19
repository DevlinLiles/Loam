using Highway.Data.QueryObjects;

namespace __NAME__.Infrastructure.Commands
{
    public class SeedDatabase : AdvancedCommand
    {
        public SeedDatabase()
        {
            ContextQuery = context =>
                {
                    //TODO Add sample entries here
                };
        }
    }
}