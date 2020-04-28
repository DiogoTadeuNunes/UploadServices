using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("Posts");

            entity.HasKey(p => p.Id);

            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            entity.Property(e => e.ProjectKey)
                .IsRequired();

            entity.Property(e => e.Title)
                .IsRequired();

            entity.Property(e => e.Content)
                .IsRequired();
        }
    }
}
