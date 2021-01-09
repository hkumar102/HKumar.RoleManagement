using HKumar.RoleManagement.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HKumar.RoleManagement.Interfaces.Services
{
    public interface IMenuBuilderService
    {
        ICollection<MenuDto> BuildMenu(ICollection<MenuDto> menuItems, MenuDto parentMenu);
    }
}
