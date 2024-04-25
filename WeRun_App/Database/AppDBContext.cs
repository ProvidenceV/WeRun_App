using Microsoft.EntityFrameworkCore;
using WeRun_App.Entities;
using WeRun_App.Models;
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
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Goal>()
                .HasKey(g => g.GoalId);

            modelBuilder.Entity<RunHistory>()
                .HasKey(h => h.HistoryId);

            modelBuilder.Entity<RunLog>()
                .HasKey(l => l.RunId); ;

            modelBuilder.Entity<Route>()
                .HasKey(r=>r.RouteId);
            
            // One-to-Many: User to Goals
            modelBuilder.Entity<User>()
                .HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);

            // One-to-Many: User to Goals
            modelBuilder.Entity<User>()
                .HasMany(u => u.RunHistory)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

            // One-to-Many: User to Routes
            modelBuilder.Entity<User>()
                .HasMany(u => u.Routes)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            //// One-to-Many: User to RunLogs
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.RunLog)
            //    .WithOne(l => l.RunLog)
            //    .HasForeignKey(l => l.UserId);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.user)
                .WithOne(b => b.user)
                .HasForeignKey<User>(b => b.Id);
        

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WeRunApp.db");
        }
    }
}
