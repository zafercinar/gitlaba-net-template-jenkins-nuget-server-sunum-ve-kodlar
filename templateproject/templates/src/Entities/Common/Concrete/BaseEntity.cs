using ZACx.Templates.WebApiProject.Entities.Common.Abstract;

namespace ZACx.Templates.WebApiProject.Entities.Common.Concrete
{
    public class BaseEntity<T> : IBaseEntity<T>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public T CreatedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public T ModifiedUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public T? DeletedUserId { get; set; }
    }
}
