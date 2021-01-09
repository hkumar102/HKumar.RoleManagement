using HKumar.RoleManagement.Interfaces.EFCore;

namespace HKumar.RoleManagement.EFCore
{
    public class DefaultDbContextSchema : IDbContextSchema
    {
        public string Schema { get; }
        public DefaultDbContextSchema(string schema)
        {
            Schema = schema;
        }

        public DefaultDbContextSchema()
        {
            Schema = Constants.DB_DEFAULT_SCHEMA;
        }
    }
}
