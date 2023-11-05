using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "dbo",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTime",
                schema: "dbo",
                columns: table => new
                {
                    ReserveTimeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveLimitCount = table.Column<int>(type: "int", nullable: false),
                    ReserveUserCount = table.Column<int>(type: "int", nullable: false),
                    TrackingBaseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReserveTimeLocked = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTime", x => x.ReserveTimeId);
                    table.ForeignKey(
                        name: "FK_ReserveTime_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTimeUser",
                schema: "dbo",
                columns: table => new
                {
                    ReserveTimeUserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveTimeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTimeUser", x => x.ReserveTimeUserId);
                    table.ForeignKey(
                        name: "FK_ReserveTimeUser_ReserveTime_ReserveTimeId",
                        column: x => x.ReserveTimeId,
                        principalSchema: "dbo",
                        principalTable: "ReserveTime",
                        principalColumn: "ReserveTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTime_DoctorId",
                schema: "dbo",
                table: "ReserveTime",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveTimeUser_ReserveTimeId",
                schema: "dbo",
                table: "ReserveTimeUser",
                column: "ReserveTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveTimeUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReserveTime",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "dbo");
        }
    }
}
