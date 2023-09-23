using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class addCommenterNameColumnToCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommenterName",
                table: "Comments",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bc298ec0-3d1e-4fa1-8689-eb591da64027");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "21e3bb89-4ee1-4a06-90a9-0b28b0b2d769");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eaf9b936-f843-4237-9640-3c8ad44c0dd4", "AQAAAAEAACcQAAAAEB4JnNPMR0PlMPXsJvORKEStPcLi0j9N2XAUdYYIDlSED+q0YKM133NJ4NZPiRZyLg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommenterName",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f258b072-04bc-4b20-b885-d748d590f73c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fdc1c8f0-95b6-4a91-9354-ee80d7602733");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0989d873-cac2-4e26-9add-b46e63c89f50", "AQAAAAEAACcQAAAAEEvVW5Op/PC0j5pnwWfuGJDZKrt6LM3UCuKbST3b2F1cw+CoI6UdXMGY/GAFsDdM6Q==" });
        }
    }
}
