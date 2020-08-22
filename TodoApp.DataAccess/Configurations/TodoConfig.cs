using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;

namespace TodoApp.DataAccess.Configurations
{
    class TodoConfig : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");
            builder.Property(td => td.Id).HasColumnName("Id");
            builder.HasKey(td => td.Id);

            builder.Property(td => td.Title)
                .HasColumnName("Title")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(td => td.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(td => td.Done)
                .HasColumnName("Completed")
                .IsRequired();

            builder.Property(td => td.Priority)
                .HasConversion(
                    v => v.ToString(),
                    v => (PriorityLevel)Enum.Parse(typeof(PriorityLevel), v));

            builder.Property(td => td.CreatedOn)
                .HasColumnName("CreatedOn")
                .IsRequired();

            builder.Property(td => td.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired();

            builder.Property(td => td.ModifiedOn)
                .HasColumnName("ModifiedOn")
                .IsRequired();

            builder.Property(td => td.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .IsRequired();
        }
    }
}
