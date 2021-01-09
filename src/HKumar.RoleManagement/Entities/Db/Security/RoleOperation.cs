using HKumar.RoleManagement.Entities.Core;
using HKumar.RoleManagement.Entities.Db.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKumar.RoleManagement.Entities.Db.Security
{
    /// <summary>
    /// Entity Define which role has access to which operation
    /// </summary>
    public class RoleOperation : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleOperationId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int OperationId { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Read { get; set; }
        public bool Delete { get; set; }

        public virtual Role Role { get; set; }
        public virtual Operation Operation  { get; set; }
    }
}
