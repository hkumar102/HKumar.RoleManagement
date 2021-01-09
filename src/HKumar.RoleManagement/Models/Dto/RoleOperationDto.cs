
namespace HKumar.RoleManagement.Models.Dto
{
    public class RoleOperationDto : BaseDto
    {
        public int RoleOperationId { get; set; }
        public int RoleId { get; set; }
        public int OperationId { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Read { get; set; }
        public bool Delete { get; set; }

        public virtual RoleDto Role { get; set; }
        public virtual OperationDto Operation { get; set; }
    }
}
