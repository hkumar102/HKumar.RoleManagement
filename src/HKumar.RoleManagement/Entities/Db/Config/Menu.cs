using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKumar.RoleManagement.Entities.Db.Config
{
    public class Menu : Core.Entity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        public string Icon { get; set; }

        public bool? IsRoot { get; set; }

        public string PageUrl { get; set; }

        public int? ParentMenuId { get; set; }

        public int MenuTypeId { get; set; }

        public int OrderNo { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
