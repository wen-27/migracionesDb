using NetTopologySuite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DerTransporte.Shared.Context;
using DerTransporte.Shared.Helpers;



var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
    

var connectionString = config.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();
services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, MySqlVersionResolver.Resolve(connectionString),
    x => x.UseNetTopologySuite()
    ));

var provider = services.BuildServiceProvider();

try
{
    using var scope = provider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (context.Database.CanConnect())
    {
        Console.WriteLine(" Conexión exitosa a la base de datos.");
    }
    else
    {
        Console.WriteLine(" No se pudo conectar con la base de datos.");
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($" Error al conectar: {ex.Message}");
    if (ex.InnerException != null)
        Console.Error.WriteLine($"   Detalle: {ex.InnerException.Message}");
}