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
            var employeeId = new[]
            {
                1,2
            };
            var name= new[]
            {
                "Nguyen Huu Tai", "Nguyen Hoang Sang"
            };
            var sogio = new[]
            {
                8,9
            };
            var sotien = new[]
            {
                16,20
            };
            var weatherForecasts = employeeId.Select(summary => new WeatherForecast
            {
               EmployeeId=summary,
             
               sogio=summary,
               sotien=summary

            }).ToArray();

            context.WeatherForecast.AddRange(weatherForecasts);

            context.SaveChanges();
        }
    }
}
