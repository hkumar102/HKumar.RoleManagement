using HKumar.RoleManagement.Interfaces.Entities;
using System;
using System.ComponentModel;

namespace HKumar.RoleManagement.Entities.Core
{

    /// <summary>
    /// Entity with default basic field without audit
    /// </summary>
    public class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }

    /// <summary>
    /// Entity with default Audit Columns
    /// </summary>
    /// <typeparam name="TUserKey">Type of Primary key for CreatedBy and UpdatedBy</typeparam>
    public class Entity<TUserKey> : Entity, IEntity<TUserKey>
        where TUserKey : struct
    {
        public TUserKey CreatedBy { get; set; }
        public TUserKey? UpdatedBy { get; set; }
    }
}
