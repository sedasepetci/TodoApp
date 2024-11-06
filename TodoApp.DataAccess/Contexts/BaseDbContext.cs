using TodoApp.Models.Entities;


using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.DataAccess.Contexts;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<ToDo> ToDos { get; set; }

    public DbSet<Category> Categories { get; set; }
 

}