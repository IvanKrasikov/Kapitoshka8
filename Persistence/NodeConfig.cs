
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Entities.Nodes;
using Domain.Shared.ValueObjects;

namespace Persistence
{
    // Класс по преобразованию Параметров в ValueObject 
    public class NodeConfig : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.ToTable("Kapitoshka");

            var nameConverter = new ValueConverter<Name, string>(
                v => v.Value,
                v => new Name(v));

            var quantityConverter = new ValueConverter<Quantity, int>(
                v => v.Value,
                v => new Quantity(v));

            var parentIdConverter = new ValueConverter<ParentId, int>(
                v => v.Value,
                v => new ParentId(v));

            builder
            .Property(p => p.Name)
                .HasConversion(nameConverter)
                .HasColumnName("Name")
                .HasColumnType("text")
                .IsRequired();

            builder
            .Property(p => p.Quantity)
                .HasConversion(quantityConverter)
                .HasColumnName("Quantity")
                .HasColumnType("int")
                .IsRequired();

            builder
            .Property(p => p.ParentId)
                .HasConversion(parentIdConverter)
                .HasColumnName("ParentId")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
