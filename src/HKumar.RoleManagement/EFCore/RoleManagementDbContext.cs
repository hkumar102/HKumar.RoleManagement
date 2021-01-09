using HKumar.RoleManagement.Entities.Db.Config;
using HKumar.RoleManagement.Entities.Db.Security;
using HKumar.RoleManagement.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;

namespace HKumar.RoleManagement.EFCore
{
    public class RoleManagementDbContext : DbContext, IDbContextSchema
    {
        public string Schema { get; }

        public RoleManagementDbContext(DbContextOptions<RoleManagementDbContext> options, IDbContextSchema schema = null) : base(options)
        {
            if (schema != null)
            {
                Schema = schema.Schema;
            }
            else
            {
                Schema = Constants.DB_DEFAULT_SCHEMA;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder
                    .Entity<Operation>()
                    .ToTable(nameof(Operation), Schema);

            modelBuilder
                    .Entity<Role>()
                    .ToTable(nameof(Role), Schema);

            modelBuilder
                    .Entity<RoleOperation>()
                    .ToTable(nameof(RoleOperation), Schema);

            modelBuilder
                    .Entity<MenuType>()
                    .ToTable(nameof(MenuType), Schema);

            modelBuilder
                    .Entity<Menu>()
                    .ToTable(nameof(Menu), Schema);

            modelBuilder
                    .Entity<RoleMenu>()
                    .ToTable(nameof(RoleMenu), Schema);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MenuType> MenuType { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<RoleOperation> RoleOperations { get; set; }

    }
}
