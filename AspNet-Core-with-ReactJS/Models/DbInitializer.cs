namespace AspNet_Core_with_ReactJS.Models
{
    public static class DbInitializer
    {
        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DatabaseContext>();
                    Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        private static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.WeatherForecast.Any())
            {
                return;   // DB has been seeded
            }

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var weatherForecasts = summaries.Select(summary => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(Array.IndexOf(summaries, summary)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summary
            }).ToArray();

            context.WeatherForecast.AddRange(weatherForecasts);

            context.SaveChanges();
        }
    }
}
