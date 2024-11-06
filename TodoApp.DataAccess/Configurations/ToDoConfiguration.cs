

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Models.Entities;

namespace TodoApp.DataAccess.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDos").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ToDoId"); 
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.Property(x => x.CreatedDate).HasColumnName("CreateDate");
        builder.Property(x => x.StartDate).HasColumnName("StartDate");
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.Completed).HasColumnName("Completed");
        builder.Property(x => x.UserId).HasColumnName("User_Id");
        builder.Property(x => x.CategoryId).HasColumnName("Category_Id");

       

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ToDos) 
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
