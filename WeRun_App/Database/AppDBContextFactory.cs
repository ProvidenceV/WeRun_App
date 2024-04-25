using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WeRun_App.Database;
public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
        optionsBuilder.UseSqlite("Data Source=mydatabase.db"); // Specify your SQLite connection string here

        return new AppDBContext(optionsBuilder.Options);
    }
}