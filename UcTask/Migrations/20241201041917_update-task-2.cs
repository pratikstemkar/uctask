using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcTask.Migrations
{
    /// <inheritdoc />
    public partial class updatetask2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_users_UserId",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tasks",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_UserId",
                table: "tasks",
                newName: "IX_tasks_user_id");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_users_user_id",
                table: "tasks",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_users_user_id",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "tasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_user_id",
                table: "tasks",
                newName: "IX_tasks_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_users_UserId",
                table: "tasks",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
