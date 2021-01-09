using HKumar.RoleManagement.Interfaces.Providers;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using UnitOfWork.Interface.Providers;

namespace HKumar.RoleManagement.Services
{
    /// <summary>
    /// Default UserInformation provider for Role Management. 
    /// Primary key for user is GUID. If you need someother type then impliment <see cref="IUserInformationProvider{TKey}"/>
    /// </summary>
    public class DefaultUserInformationProvider : IRoleManagementUserInformationProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DefaultUserInformationProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        #region Public Methods
        public Guid UserId => this.GetUserId();
        public Guid TenantId => this.GetTenantId();
        public string UserName => this.GetUserName();
        public int[] UserRoleIds => this.GetUserRoleIds();
        public string[] UserRoleNames => this.GetUserRoleNames();
        public bool IsAuthenticated() => this.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        #endregion

        #region Private Methods
        private string GetUserName()
        {
            if (!this.IsAuthenticated())
            {
                return string.Empty;
            }

            return this.httpContextAccessor.HttpContext.User.Claims
                .First(claim => claim.Type == JwtClaimTypes.PreferredUserName).Value;
        }


        private Guid GetUserId()
        {
            if (!this.IsAuthenticated()) return Guid.Empty;

            var idClaim = this.httpContextAccessor.HttpContext.User.Claims
                .First(claim => claim.Type == ClaimTypes.NameIdentifier);

            return Guid.Parse(idClaim.Value);
        }

        private Guid GetTenantId()
        {
            if (!this.IsAuthenticated()) return Guid.Empty;

            var idClaim = this.httpContextAccessor.HttpContext.User.Claims
               .First(claim => claim.Type == "tenantId");

            return Guid.Parse(idClaim.Value);
        }

        private int[] GetUserRoleIds()
        {
            if (!this.IsAuthenticated()) return default;

            return this.httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "roleid").Select(x => Convert.ToInt32(x.Value)).ToArray();
        }

        private string[] GetUserRoleNames()
        {
            if (!this.IsAuthenticated()) return default;

            return this.httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "role").Select(x => (x.Value)).ToArray();
        }
        #endregion
    }
}
