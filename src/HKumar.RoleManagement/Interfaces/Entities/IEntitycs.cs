
using System;

namespace HKumar.RoleManagement.Interfaces.Entities
{
    public interface IEntity : ISoftDeleteEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }

    public interface IEntity<TUserKey> : IEntity
        where TUserKey : struct
    {
        TUserKey CreatedBy { get; set; }
        TUserKey? UpdatedBy { get; set; }
    }
}
