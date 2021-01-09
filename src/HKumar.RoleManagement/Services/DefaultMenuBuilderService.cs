using HKumar.RoleManagement.Enums;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKumar.RoleManagement.Services
{
    public class DefaultMenuBuilderService : IMenuBuilderService
    {
        public ICollection<MenuDto> BuildMenu(ICollection<MenuDto> menuItems, MenuDto parentMenu)
        {
            try
            {
                if (parentMenu != null)
                {
                    var childMenuItems = menuItems.Where(x => x.ParentMenuId == parentMenu.MenuId);
                    if (childMenuItems.Any())
                    {
                        foreach (var childMenu in childMenuItems)
                        {
                            childMenu.ChildMenus = BuildMenu(menuItems, childMenu);
                        }
                    }

                    return childMenuItems.ToList();
                }
                else
                {
                    var sectionMenuItems = menuItems.Where(x => x.MenuType.MenuTypeId == (int)MenuTypeEnum.Section);
                    if (sectionMenuItems.Any())
                    {
                        foreach (var section in sectionMenuItems)
                        {
                            section.ChildMenus = BuildMenu(menuItems, section);
                        }
                    }

                    return sectionMenuItems.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}
