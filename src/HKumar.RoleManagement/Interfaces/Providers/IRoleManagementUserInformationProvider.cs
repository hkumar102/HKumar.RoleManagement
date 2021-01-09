using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interface.Providers;

namespace HKumar.RoleManagement.Interfaces.Providers
{
    public interface IRoleManagementUserInformationProvider : IUserInformationProvider<Guid>
    {
        string UserName { get; }

        bool IsAuthenticated();

        Guid TenantId { get; }

        int[] UserRoleIds { get; }

        string[] UserRoleNames { get; }
    }
}
