using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class timesbool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarberInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimesAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAvailableBool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    BarberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    ServiceDuration = table.Column<int>(type: "int", nullable: false),
                    ServiceCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDuration = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    ServiceSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberInfo");

            migrationBuilder.DropTable(
                name: "BookingInfo");

            migrationBuilder.DropTable(
                name: "ServiceInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
