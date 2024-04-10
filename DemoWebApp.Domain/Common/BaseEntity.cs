using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Domain.Common
{
    public class BaseEntity
    {
        [Column("CREATE_BY")]
        public string? CreateBy { get; set; }
        [Column("CREATE_DATE")]
        public DateTime? CreateDate { get; set; }
        [Column("LT_UPDATE_DATE")]
        public DateTime? LastUpdateDate { get; set; }
        [Column("LT_UPDATE_BY")]
        public string? LastUpdateBy { get; set; }
        [Column("IS_DELETED")]
        public bool? IsDeleted { get; set; }
    }
}
