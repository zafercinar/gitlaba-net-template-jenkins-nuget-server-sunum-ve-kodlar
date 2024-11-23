using ZACx.Templates.WebApiProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZACx.Templates.WebApiProject.DataAccess.EntityConfigurations.DataConfigurations
{
    public class ExampleEntityDataConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.HasData(new Example
            {
                ExampleId = 1,
                Code = "ZC",
                Name = "Örnek şablon",
                Description = "Örnek şablon için yapılan açıklama bilgisidir",
                DoSendMail = true,
                IsActive = true,
                IsDeleted = false,
                CreatedUserId = 69227,
                CreatedTime = DateTime.Now,
                ModifiedUserId = 69227,
                ModifiedTime = DateTime.Now
            });
        }
    }
}
