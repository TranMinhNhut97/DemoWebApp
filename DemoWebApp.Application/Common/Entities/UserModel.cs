using DemoWebApp.Domain.Common;

namespace DemoWebApp.Application.Common.Entities
{
    public class UserModel : BaseEntity
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
