using AutoMapper;
using AutoMapper.QueryableExtensions;
using HKumar.RoleManagement.EFCore;
using HKumar.RoleManagement.Entities.Db.Config;
using HKumar.RoleManagement.Entities.Db.Security;
using HKumar.RoleManagement.Extensions;
using HKumar.RoleManagement.Interfaces.Providers;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace HKumar.RoleManagement.Services
{
    
    public class RoleManagementService : IRoleManagementService
    {

        private readonly ICacheProvider _cacheProvider;
        private readonly IUnitOfWork<Guid, RoleManagementDbContext> _unitOfWork;
        private readonly IMenuBuilderService _menuBuilderService;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<RoleMenu> _roleMenuRepository;
        private readonly IRepository<Operation> _operationRepository;
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<MenuType> _menuTypeRepository;
        private readonly IRepository<RoleOperation> _roleOperationRepository;
        private readonly ILogger<RoleManagementService> _logger;

        public RoleManagementService(
            ICacheProvider cacheProvider,
            IMenuBuilderService menuBuilderService,
            IMapper mapper,
            IUnitOfWork<Guid, RoleManagementDbContext> unitOfWork,
            ILogger<RoleManagementService> logger)
        {
            _cacheProvider = cacheProvider;
            _unitOfWork = unitOfWork;
            _menuBuilderService = menuBuilderService;
            _mapper = mapper;
            _roleRepository = unitOfWork.GetRepository<Role>();
            _roleMenuRepository = unitOfWork.GetRepository<RoleMenu>();
            _operationRepository = unitOfWork.GetRepository<Operation>();
            _menuRepository = unitOfWork.GetRepository<Menu>();
            _menuTypeRepository = unitOfWork.GetRepository<MenuType>();
            _roleOperationRepository = unitOfWork.GetRepository<RoleOperation>();
        }


        /// <summary>
        /// Clear the cache for the old roles for a Tenant
        /// </summary>
        void RemoveRoleCache()
        {
            string cacheKey = $"roles:";
            _cacheProvider.RemoveObj(cacheKey);
        }

        /// <summary>
        /// Clear the cache for the old roles for a Tenant
        /// </summary>
        void RemoveRoleOperationCache()
        {
            string cacheKey = $"RoleOperation:";
            _cacheProvider.RemoveObj(cacheKey);
        }

        public async Task<RoleDto> AddRoleAsync(RoleDto model)
        {
            try
            {
                var dbEntity = model.ToEntity<Role>(_mapper);
                await _roleRepository.InsertAsync(dbEntity);
                int result = await _unitOfWork.SaveChangesAsync();
                model.RoleId = dbEntity.RoleId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            return model;
        }

        public async Task<RoleMenuDto> AddRoleMenuAsync(RoleMenuDto model)
        {
            try
            {
                var existingMenu = await _roleMenuRepository.ExistsAsync(x => x.RoleId == model.RoleId && x.MenuId == model.MenuId);
                if (!existingMenu)
                {
                    var dbEntity = model.ToEntity<RoleMenu>(_mapper);
                    await _roleMenuRepository.InsertAsync(dbEntity);
                    await _unitOfWork.SaveChangesAsync();
                    model.RoleMenuId = dbEntity.RoleMenuId;
                }
                else
                {
                    throw new ApplicationException("RoleMenu already exist.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            return model;
        }

        public async Task<RoleOperationDto> AddRoleOperationAsync(RoleOperationDto model)
        {
            try
            {
                var existingPermission = await _roleOperationRepository.ExistsAsync(x => x.RoleId == model.RoleId && x.OperationId == model.OperationId);
                if (!existingPermission)
                {
                    var dbEntity = model.ToEntity<RoleOperation>(_mapper);
                    await _roleOperationRepository.InsertAsync(dbEntity);
                    await _unitOfWork.SaveChangesAsync();
                    model.RoleOperationId = dbEntity.RoleOperationId;
                }
                else
                {
                    throw new ApplicationException("RoleOperation already exist.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
            return model;
        }

        public async Task DeleteRoleAsync(RoleDto model)
        {
            try
            {
                var dbEntity = await _roleRepository.FindAsync(model.RoleId);
                _roleRepository.Delete(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task DeleteRoleMenuAsync(RoleMenuDto model)
        {
            try
            {

                var dbEntity = await _roleMenuRepository.FindAsync(model.RoleMenuId);
                _roleMenuRepository.Delete(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task DeleteRoleOperationAsync(RoleOperationDto model)
        {
            try
            {
                var dbEntity = await _roleOperationRepository.FindAsync(model.RoleOperationId);
                _roleOperationRepository.Delete(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<ICollection<MenuDto>> GetMenusAsync()
        {

            var menus = await _menuRepository.GetAll().ProjectTo<MenuDto>(_mapper.ConfigurationProvider).ToListAsync();
            var result = _menuBuilderService.BuildMenu(menus, null);
            return result;
        }

        public async Task<ICollection<OperationDto>> GetOperationAsync()
        {
            var operations = await _operationRepository.GetAll().ProjectTo<OperationDto>(_mapper.ConfigurationProvider).ToListAsync();
            return operations;
        }

        public async Task<RoleDto> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.FindAsync(roleId);
            return role.ToModelDto<RoleDto>(_mapper);
        }

        public async Task<ICollection<RoleMenuDto>> GetRoleMenuAsync()
        {
            return await _roleMenuRepository.GetAll().ProjectTo<RoleMenuDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ICollection<RoleMenuDto>> GetRoleMenuByRoleIdAsync(int roleId)
        {
            var dbItems = await _roleMenuRepository.WhereAsync(x => x.RoleId == roleId, include: (i) => i.Include(x => x.Role).Include(x => x.Menu));
            var dtoItems = _mapper.Map<ICollection<RoleMenuDto>>(dbItems);
            return dtoItems;
        }

        public async Task<ICollection<RoleOperationDto>> GetRoleOperationByRoleIdAsync(int roleId)
        {
            var dbItems = await _roleOperationRepository.WhereAsync(x => x.RoleId == roleId, include: (i) => i.Include(x => x.Role).Include(x => x.Operation));
            var dtoItems = _mapper.Map<ICollection<RoleOperationDto>>(dbItems);
            return dtoItems;
        }

        public async Task<ICollection<RoleOperationDto>> GetRoleOperationAsync()
        {
            return await _roleOperationRepository.GetAll().ProjectTo<RoleOperationDto>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task<ICollection<RoleDto>> GetRolesAsync()
        {
            return await _roleRepository.GetAll().ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task UpdateRoleAsync(RoleDto model)
        {
            try
            {
                var dbEntity = await _roleRepository.FindAsync(model.RoleId);
                dbEntity = model.PatchEntity(dbEntity, _mapper);
                _roleRepository.Update(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task UpdateRoleMenuAsync(RoleMenuDto model)
        {
            try
            {
                var dbEntity = await _roleMenuRepository.FindAsync(model.RoleId);
                dbEntity = model.PatchEntity(dbEntity, _mapper);
                _roleMenuRepository.Update(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task UpdateRoleOperationAsync(RoleOperationDto model)
        {
            try
            {
                var dbEntity = await _roleOperationRepository.FindAsync(model.RoleId);
                dbEntity = model.PatchEntity(dbEntity, _mapper);
                _roleOperationRepository.Update(dbEntity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
