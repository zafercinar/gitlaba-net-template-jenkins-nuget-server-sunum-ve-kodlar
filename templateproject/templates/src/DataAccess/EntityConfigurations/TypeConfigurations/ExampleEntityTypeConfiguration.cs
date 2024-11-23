using ZACx.Templates.WebApiProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZACx.Templates.WebApiProject.DataAccess.EntityConfigurations.TypeConfigurations
{
    public class ExampleEntityTypeConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.ToTable("Examples", "DbSchemaAdi");

            builder.HasKey(e => e.ExampleId);

            builder.Property(p => p.ExampleId)
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                   .HasColumnType("varchar")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.Property(p => p.DoSendMail)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(e => e.CreatedTime)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.Property(e => e.CreatedUserId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(e => e.ModifiedTime)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.ModifiedUserId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(e => e.DeletedTime)
                   .IsRequired(false);

            builder.Property(e => e.DeletedUserId)
                   .HasColumnType("int")
                   .IsRequired(false);

            builder.HasIndex(p => new { p.Code }).IsUnique();
        }
    }
}
