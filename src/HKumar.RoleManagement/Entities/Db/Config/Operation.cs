using HKumar.RoleManagement.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HKumar.RoleManagement.Entities.Db.Config
{
    /// <summary>
    /// Operation Entity Define the functionalities provided by the system
    /// </summary>
    public class Operation : Entity
    {

        /// <summary>
        /// Primary key of the Operation
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationId { get; set; }
        /// <summary>
        /// Name of the Operation
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string ControllerName { get; set; }
    }
}
