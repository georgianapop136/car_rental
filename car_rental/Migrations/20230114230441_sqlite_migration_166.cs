using Microsoft.EntityFrameworkCore.Migrations;

namespace car_rental.Migrations
{
    public partial class sqlite_migration_166 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id_Booking = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start_Booking = table.Column<string>(nullable: true),
                    End_Booking = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Id_Car = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id_Booking);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Transmission = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Name_Customer = table.Column<string>(nullable: true),
                    State = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
