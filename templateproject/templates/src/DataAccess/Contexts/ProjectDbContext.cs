using ZACx.Templates.WebApiProject.DataAccess.EntityConfigurations.DataConfigurations;
using ZACx.Templates.WebApiProject.DataAccess.EntityConfigurations.TypeConfigurations;
using ZACx.Templates.WebApiProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZACx.Templates.WebApiProject.DataAccess.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Type Configurations
            modelBuilder.ApplyConfiguration(new ExampleEntityTypeConfiguration());

            //Data Seed Configurations
            modelBuilder.ApplyConfiguration(new ExampleEntityDataConfiguration());
        }
    }
}
