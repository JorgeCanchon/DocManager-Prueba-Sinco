using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocManager.InfrastructureEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentInstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpedienteTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniqueIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FieldDataJson = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentInstance_DocumentType_ExpedienteTypeId",
                        column: x => x.ExpedienteTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpedienteTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypeField_DocumentType_ExpedienteTypeId",
                        column: x => x.ExpedienteTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpedienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileNameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFile_DocumentInstance_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "DocumentInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldListOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldListOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldListOption_DocumentTypeField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "DocumentTypeField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFile_ExpedienteId",
                table: "DocumentFile",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInstance_ExpedienteTypeId",
                table: "DocumentInstance",
                column: "ExpedienteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInstance_UniqueIdentifier",
                table: "DocumentInstance",
                column: "UniqueIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_Name",
                table: "DocumentType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeField_ExpedienteTypeId",
                table: "DocumentTypeField",
                column: "ExpedienteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldListOption_CustomFieldId",
                table: "FieldListOption",
                column: "CustomFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentFile");

            migrationBuilder.DropTable(
                name: "FieldListOption");

            migrationBuilder.DropTable(
                name: "DocumentInstance");

            migrationBuilder.DropTable(
                name: "DocumentTypeField");

            migrationBuilder.DropTable(
                name: "DocumentType");
        }
    }
}
