using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApi.Migrations
{
    public partial class UpdatedTimestampColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Todo",
                newName: "CreatedTimestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Todo",
                newName: "CreatedDate");
        }
    }
}
