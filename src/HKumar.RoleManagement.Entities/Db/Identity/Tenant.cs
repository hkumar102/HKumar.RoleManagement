using HKumar.RoleManagement.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKumar.RoleManagement.Entities.Db.Identity
{
    public class Tenant
    {
        [Required]
        public int TenantId { get; set; }

        [Required]
        [MaxLength(500)]
        public string TenantName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
