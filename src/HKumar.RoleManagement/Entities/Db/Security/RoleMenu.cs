using HKumar.RoleManagement.Entities.Db.Config;
using System.ComponentModel.DataAnnotations;

namespace HKumar.RoleManagement.Entities.Db.Security
{
    public class RoleMenu : Core.Entity
    {
        public int RoleMenuId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int MenuId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
