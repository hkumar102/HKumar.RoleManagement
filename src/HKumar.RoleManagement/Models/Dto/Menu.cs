using System.Collections.Generic;

namespace HKumar.RoleManagement.Models.Dto
{
    public class MenuDto : BaseDto
    {

        public int MenuId { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public bool? IsRoot { get; set; }

        public string PageUrl { get; set; }

        public int? ParentMenuId { get; set; }

        public int MenuTypeId { get; set; }

        public int OrderNo { get; set; }

        public virtual MenuTypeDto MenuType { get; set; }

        public ICollection<MenuDto> ChildMenus { get; set; }

    }
}
