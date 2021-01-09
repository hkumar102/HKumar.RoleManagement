using HKumar.RoleManagement.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace HKumar.RoleManagement.Entities.Db.Security
{
    public class Role : Entity<Guid>
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(200)]
        public string RoleName { get; set; }
    }
}
