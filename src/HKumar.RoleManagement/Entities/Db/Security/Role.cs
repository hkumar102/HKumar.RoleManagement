using HKumar.RoleManagement.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKumar.RoleManagement.Entities.Db.Security
{
    public class Role : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(200)]
        public string RoleName { get; set; }
    }
}
