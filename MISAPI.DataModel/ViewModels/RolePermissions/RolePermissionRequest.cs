using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class RolePermissionRequest
    {
        [Required, MaxLength(75)]
        public string MenuId { get; set; }
                
        [MaxLength(75)]
        public string SubMenuId { get; set; }

        [Required, MaxLength(75)]
        public string OperationId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public long UserLogId { get; set; }
        public long? UpdateLogId { get; set; }

    }
}
