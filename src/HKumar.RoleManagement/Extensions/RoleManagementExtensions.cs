using AutoMapper;
using HKumar.RoleManagement.Interfaces.Entities;
using HKumar.RoleManagement.Models.Dto;
using System;
using System.Linq;

namespace HKumar.RoleManagement.Extensions
{
    public static class RoleManagementExtensions
    {
        public static TEntity ToEntity<TEntity>(this BaseDto model, IMapper mapper)
        {
            return mapper.Map<TEntity>(model);
        }

        public static TModel ToModelDto<TModel>(this IEntity entity, IMapper mapper)
        {
            return mapper.Map<TModel>(entity);
        }

        public static TEntity PatchEntity<TEntity>(this BaseDto model, TEntity dbEntity, IMapper mapper)
        {
            var dbModel = model.ToEntity<TEntity>(mapper);
            var notNullProeprties = dbModel
                                        .GetType()
                                        .GetProperties()
                                        .Where(x => !CheckNullOrEmpty(x.GetValue(dbModel, null))).ToList();
            foreach (var property in notNullProeprties)
            {
                var dbProperty = dbEntity.GetType().GetProperty(property.Name);

                if (dbProperty != null)
                {
                    if (property.GetValue(dbModel, null) != dbProperty.GetValue(dbEntity, null))
                    {
                        if (dbProperty != null)
                        {
                            property.SetValue(dbEntity, dbProperty.GetValue(dbModel, null));
                        }

                    }
                }

            }
            return dbEntity;
        }

        private static bool CheckNullOrEmpty(object value)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is int)
            {
                return Convert.ToInt64(value) == 0;
            }
            else if (value is Guid)
            {
                return Guid.Parse(value.ToString()) == Guid.Empty;
            }
            else if (value is Nullable)
            {
                return value == null;
            }

            return false;
        }
    }
}
