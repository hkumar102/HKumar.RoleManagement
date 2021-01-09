using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HKumar.RoleManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RoleManagement");

            migrationBuilder.CreateTable(
                name: "MenuType",
                schema: "RoleManagement",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuType", x => x.MenuTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                schema: "RoleManagement",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "RoleManagement",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "RoleManagement",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRoot = table.Column<bool>(type: "bit", nullable: true),
                    PageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentMenuId = table.Column<int>(type: "int", nullable: true),
                    MenuTypeId = table.Column<int>(type: "int", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menu_MenuType_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalSchema: "RoleManagement",
                        principalTable: "MenuType",
                        principalColumn: "MenuTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperation",
                schema: "RoleManagement",
                columns: table => new
                {
                    RoleOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    Create = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperation", x => x.RoleOperationId);
                    table.ForeignKey(
                        name: "FK_RoleOperation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "RoleManagement",
                        principalTable: "Operation",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOperation_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "RoleManagement",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                schema: "RoleManagement",
                columns: table => new
                {
                    RoleMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.RoleMenuId);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "RoleManagement",
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "RoleManagement",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuTypeId",
                schema: "RoleManagement",
                table: "Menu",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                schema: "RoleManagement",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_RoleId",
                schema: "RoleManagement",
                table: "RoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperation_OperationId",
                schema: "RoleManagement",
                table: "RoleOperation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperation_RoleId",
                schema: "RoleManagement",
                table: "RoleOperation",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMenu",
                schema: "RoleManagement");

            migrationBuilder.DropTable(
                name: "RoleOperation",
                schema: "RoleManagement");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "RoleManagement");

            migrationBuilder.DropTable(
                name: "Operation",
                schema: "RoleManagement");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "RoleManagement");

            migrationBuilder.DropTable(
                name: "MenuType",
                schema: "RoleManagement");
        }
    }
}
