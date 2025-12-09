using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCWebAppMySql.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(entity =>
            {
                entity.Property(u => u.Id).HasMaxLength(191).HasColumnType("varchar(191)");
                entity.Property(u => u.UserName).HasMaxLength(191);
                entity.Property(u => u.NormalizedUserName).HasMaxLength(191);
                entity.Property(u => u.Email).HasMaxLength(191);
                entity.Property(u => u.NormalizedEmail).HasMaxLength(191);
                entity.Property(u => u.ConcurrencyStamp).HasColumnType("longtext");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(r => r.Id).HasMaxLength(191).HasColumnType("varchar(191)");
                entity.Property(r => r.Name).HasMaxLength(191);
                entity.Property(r => r.NormalizedName).HasMaxLength(191);
                entity.Property(r => r.ConcurrencyStamp).HasColumnType("longtext");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(l => l.LoginProvider).HasMaxLength(191);
                entity.Property(l => l.ProviderKey).HasMaxLength(191);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(ur => ur.UserId).HasMaxLength(191);
                entity.Property(ur => ur.RoleId).HasMaxLength(191);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(t => t.LoginProvider).HasMaxLength(191);
                entity.Property(t => t.Name).HasMaxLength(191);
            });
        }

    }
}
