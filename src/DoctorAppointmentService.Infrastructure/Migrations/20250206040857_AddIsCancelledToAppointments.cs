using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointmentService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCancelledToAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Appointments");
        }
    }
}
