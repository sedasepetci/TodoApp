using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models.Entities;

namespace TodoApp.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CategoryId");
            builder.Property(x => x.CreatedDate).HasColumnName("CreateDate");
            builder.Property(x => x.Name).HasColumnName("CategoryName");

            builder.HasMany(x => x.ToDos)
             .WithOne(x => x.Category) 
             .HasForeignKey(x => x.CategoryId)
             .OnDelete(DeleteBehavior.NoAction); 



            builder.HasData(new Category
            {
                Id = 1,
                Name = "Ders",
                CreatedDate = DateTime.Now
            });
           
        }
    }
}
