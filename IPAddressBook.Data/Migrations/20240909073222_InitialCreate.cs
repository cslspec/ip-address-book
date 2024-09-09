using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPAddressBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPAddressBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPAddressBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPv4Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Octet1 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Octet2 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Octet3 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Octet4 = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPv4Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPv4Addresses_IPAddressBase_Id",
                        column: x => x.Id,
                        principalTable: "IPAddressBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPv6Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Group1 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group2 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group3 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group4 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group5 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group6 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group7 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Group8 = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPv6Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPv6Addresses_IPAddressBase_Id",
                        column: x => x.Id,
                        principalTable: "IPAddressBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPv4Addresses");

            migrationBuilder.DropTable(
                name: "IPv6Addresses");

            migrationBuilder.DropTable(
                name: "IPAddressBase");
        }
    }
}
