using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HKumar.RoleManagement.Entities.Db.Config
{
    public class MenuType : Core.Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuTypeId { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(4)]
        [Required]
        public string Code { get; set; }
    }
}
