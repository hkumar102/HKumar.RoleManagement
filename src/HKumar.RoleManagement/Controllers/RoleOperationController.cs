using HKumar.RoleManagement.Attributes;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interface.Providers;

namespace HKumar.RoleManagement.Controllers
{
    /// <summary>
    /// Account controller for handling security related things
    /// </summary>
    [Route("RoleManagement/[controller]")]
    [RoleAutorize]
    public class RoleOperationController : ControllerBase
    {
        #region Private properties
        private readonly IRoleManagementService _roleManagementService;
        private readonly IUserInformationProvider _userInformationProvider;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityService"></param>
        /// <param name="userInformationProvider"></param>
        public RoleOperationController(
            IRoleManagementService securityService,
            IUserInformationProvider userInformationProvider)
        {
            _roleManagementService = securityService;
            _userInformationProvider = userInformationProvider;

        }

        /// <summary>
        /// Return the roles for the tenants
        /// </summary>
        /// <returns>PageResult&lt;RoleOperationDto&gt;</returns>
        [HttpGet]
        public async Task<ICollection<RoleOperationDto>> GetRoleOperations()
        {
            return await _roleManagementService.GetRoleOperationAsync();
        }

        /// <summary>
        /// Return the RoleOperations by roleid
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("{roleId}")]
        public async Task<ICollection<RoleOperationDto>> GetRoleOperationByRoleId(int roleId)
        {
            return await _roleManagementService.GetRoleOperationByRoleIdAsync(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostRoleOperation([FromBody] RoleOperationDto model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _roleManagementService.AddRoleOperationAsync(model);
            return Ok(result);

        }

        /// <summary>
        /// Delete role by id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteRoleOperation(RoleOperationDto model)
        {
            await _roleManagementService.DeleteRoleOperationAsync(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> PatchRoleOperation([FromBody] RoleOperationDto model)
        {
            if (model == null) return BadRequest();

            await _roleManagementService.UpdateRoleOperationAsync(model);

            return NoContent();

        }

    }
}
