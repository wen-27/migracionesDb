using Microsoft.EntityFrameworkCore;

namespace DerTransporte.Shared.Helpers;

public class MySqlVersionResolver
{
    public static ServerVersion Resolve(string connectionString)
        => ServerVersion.AutoDetect(connectionString);
}
