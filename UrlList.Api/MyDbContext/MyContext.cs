using Microsoft.EntityFrameworkCore;
using UrlList.Api.Entities;

namespace UrlList.Api.MyDbContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }
        public DbSet<Entities.UrlListEntity> UrlLists { get; set; }
        public DbSet<UrlItemEntity> UrlItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlListEntity>()
                .HasKey(nameof(UrlListEntity.TitleId), nameof(UrlItemEntity.UrlItemId));
        }
    }
}
