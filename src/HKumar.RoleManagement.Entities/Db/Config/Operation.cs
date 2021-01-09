using HKumar.RoleManagement.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HKumar.RoleManagement.Entities.Db.Config
{
    /// <summary>
    /// Operation Entity Define the functionalities provided by the system
    /// </summary>
    [Table("Operation", Schema = Constants.DB_SCHEMA_CONFIG)]
    public class Operation : Entity
    {

        /// <summary>
        /// Primary key of the Operation
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperationId { get; set; }
        /// <summary>
        /// Name of the Operation
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
