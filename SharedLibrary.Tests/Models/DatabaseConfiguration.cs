namespace K9.SharedLibrary.Tests.Models
{
    public class DatabaseConfiguration
    {
        public bool AutomaticMigrationsEnabled { get; set; }

        public bool AutomaticMigrationDataLossAllowed { get; set; }

        public string SystemUserPassword { get; set; }

        public string DefaultUserPassword { get; set; }
    }
}