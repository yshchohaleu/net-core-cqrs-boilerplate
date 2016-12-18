using CqrsBoilerplate.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CqrsBoilerplate.Entities.Contexts
{
    public class UsersContext : DataContext
    {
        public UsersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);

            builder.Entity<Membership>(entity =>
            {
                entity.HasKey(p => p.UserId);
                entity.ToTable("membership");

                entity.HasOne(x => x.User).WithOne(x => x.Membership).IsRequired();
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("user");

                entity.HasOne(x => x.Membership).WithOne(x => x.User).IsRequired();
                entity.HasOne(x => x.UserInfo).WithOne(x => x.User);
            });

            builder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(p => p.UserId);
                entity.ToTable("user_info");

                entity.HasOne(x => x.User).WithOne(x => x.UserInfo).IsRequired();
            });
        }
    }
}
