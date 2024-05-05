using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALOPER.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    rentalTerm = table.Column<int>(type: "int", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositAmount = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<int>(type: "int", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    NumberOfVehicle = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    BirthOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Identification = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DateRange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    IdFurniture = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ContractId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.IdFurniture);
                    table.ForeignKey(
                        name: "FK_Furnitures_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false),
                    PriceService = table.Column<int>(type: "int", nullable: false),
                    Dvt = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    OldNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContractId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                    table.ForeignKey(
                        name: "FK_Services_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_ContractId",
                table: "Furnitures",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractId",
                table: "Services",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
