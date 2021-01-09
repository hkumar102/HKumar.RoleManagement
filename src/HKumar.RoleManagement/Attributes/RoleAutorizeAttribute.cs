using HKumar.RoleManagement.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using HKumar.RoleManagement.Interfaces.Providers;
using Microsoft.AspNetCore.Mvc;

namespace HKumar.RoleManagement.Attributes
{
    /// <summary>
    /// Attibute to validate if user has access to that endpoint
    /// This attribute require <see cref="IRoleManagementUserInformationProvider"/> to get the user roles
    /// </summary>
    public class RoleAutorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var errorId = Guid.NewGuid();
            var isValid = true;
            var message = "Unauthorized";
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                isValid = false;
            }
            else
            {
                message = $"You are not authorized to perform this action.";
                isValid = false;
                IRoleManagementService securityService = context.HttpContext.RequestServices.GetService<IRoleManagementService>();
                IRoleManagementUserInformationProvider userInformationProvider = context.HttpContext.RequestServices.GetService<IRoleManagementUserInformationProvider>();

                var userRoles = userInformationProvider.UserRoleIds;
                var rolePermissions = securityService.GetRoleOperationAsync().Result;
                var userRolesPermission = from userRole in userRoles join rolePermission in rolePermissions on userRole equals rolePermission.RoleId select rolePermission;
                var controllername = context.RouteData.Values["controller"].ToString();
                switch (context.HttpContext.Request.Method.ToLowerInvariant())
                {
                    case "get":
                        isValid = userRolesPermission.Where(x => x.Read == true && x.Operation.ControllerName == controllername).Any();
                        break;
                    case "post":
                        isValid = userRolesPermission.Where(x => x.Create == true && x.Operation.ControllerName == controllername).Any();
                        break;
                    case "patch":
                    case "put":
                        isValid = userRolesPermission.Where(x => x.Update == true && x.Operation.ControllerName == controllername).Any();
                        break;
                    case "delete":
                        isValid = userRolesPermission.Where(x => x.Delete == true && x.Operation.ControllerName == controllername).Any();
                        break;
                    default:
                        isValid = true; // We dont care about other verbs because we are not handling it.
                        break;
                }
            }

            if (!isValid)
            {
                context.Result = new ObjectResult(new ProblemDetails()
                {
                    Status = 401,
                    Detail = message,
                    Title = message
                });
            }
        }
    }
}
