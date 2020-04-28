using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    class FileMap : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> entity)
        {
            entity.ToTable("Files");

            entity.HasKey(p => p.Id);

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.Session)
                .IsRequired();

            entity
                .HasOne(x => x.Post)
                .WithMany(x => x.Files)
                .HasForeignKey(x => x.PostId);
        }
    }
}
