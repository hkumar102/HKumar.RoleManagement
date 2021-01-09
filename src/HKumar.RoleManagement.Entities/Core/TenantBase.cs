using HKumar.RoleManagement.Entities.Db.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace HKumar.RoleManagement.Entities.Core
{
    public class TenantBase : Entity<Guid>
    {
        [Required]
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
