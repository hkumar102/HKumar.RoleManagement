
namespace HKumar.RoleManagement.Models.Dto
{
    public class RoleMenuDto : BaseDto
    {
        public int RoleMenuId { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual RoleDto Role { get; set; }
        public virtual MenuDto Menu { get; set; }
    }
}
