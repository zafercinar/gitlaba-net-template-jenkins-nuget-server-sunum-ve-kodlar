using ZACx.Templates.WebApiProject.Entities.Common.Concrete;

namespace ZACx.Templates.WebApiProject.Entities.Entities
{
    public class Example : BaseEntity<int>
    {
        public int ExampleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool DoSendMail { get; set; }
    }
}
