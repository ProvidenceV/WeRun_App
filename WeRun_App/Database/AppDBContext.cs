using Microsoft.EntityFrameworkCore;
using WeRun_App.Entities;
using Route = WeRun_App.Entities.Route;

namespace WeRun_App.Database
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<RunHistory> RunHistory { get; set; }
        public DbSet<RunLog> RunLog { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();

            modelBuilder.Entity<Goal>();

            modelBuilder.Entity<RunHistory>();

            modelBuilder.Entity<RunLog>();

            modelBuilder.Entity<Route>();

            // One-to-Many: User to Goals
            modelBuilder.Entity<User>()
                .HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);

            // One-to-Many: User to Goals
            modelBuilder.Entity<User>()
                .HasMany(u => u.RunHistory)
                .WithOne(rh => rh.User)
                .HasForeignKey(rh => rh.UserId);

            // One-to-Many: User to Routes
            modelBuilder.Entity<User>()
                .HasMany(u => u.Routes)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //      {
    //          optionsBuilder.UseSqlite("Data Source=WeRunApp.db");
    //      }


}
