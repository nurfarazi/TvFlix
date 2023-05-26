using Core.Entity;
using Core.Entity.Movies;
using Core.Entity.Series;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>, AppUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Series> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>(b =>
        {
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<AppRole>(b =>
        {
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        });
    }
}