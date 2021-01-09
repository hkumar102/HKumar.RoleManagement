
namespace HKumar.RoleManagement.Models.Dto
{
    public class OperationDto : BaseDto
    {
        public int OperationId { get; set; }

        public string Name { get; set; }

        public string ControllerName { get; set; }
    }
}
