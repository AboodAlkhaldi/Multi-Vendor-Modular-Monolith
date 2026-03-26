namespace BuildingBlocks.Data
{
    public static class DbContextExtensions
    {
        public static DbContextOptionsBuilder ConfigurePostgreSql(
            this DbContextOptionsBuilder optionsBuilder,
            string connectionString,
            string schemaName,
            string migrationsAssembly,
            DatabaseOptions? options = null
        )
        {
            options ??= new DatabaseOptions(); // from the configuration (appsettings.json)

            optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(migrationsAssembly);
                npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", schemaName);
                npgsqlOptions.CommandTimeout(options.CommandTimeoutInSeconds);
                npgsqlOptions.EnableRetryOnFailure(options.MaxRetryCount, TimeSpan.FromSeconds(options.MaxRetryDelayInSeconds), null);
            });

            if (options.EnableSensitiveDataLogging)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
            if(options.EnableDetailedErrors)
            {
                optionsBuilder.EnableDetailedErrors();
            }

            return optionsBuilder;


        }
    }
}