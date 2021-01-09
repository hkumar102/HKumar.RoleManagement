using System;
using System.Collections.Generic;
using System.Text;

namespace HKumar.RoleManagement.Interfaces.Entities
{
    /// <summary>
    /// Interface to implement soft delete for a Entity
    /// </summary>
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
