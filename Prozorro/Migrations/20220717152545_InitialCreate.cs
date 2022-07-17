using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prozorro.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Uri = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Scheme = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FaxNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinOrderValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinOrderValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    ValueAddetTaxIncluded = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedProduct = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinOrderValueId = table.Column<int>(type: "INTEGER", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDTOs_MinOrderValue_MinOrderValueId",
                        column: x => x.MinOrderValueId,
                        principalTable: "MinOrderValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferDTOs_Value_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ClassificationId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedCategory = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Value_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", nullable: false),
                    Locality = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    OfferDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAddress_OfferDTOs_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "OfferDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Сriterion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сriterion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сriterion_ProfileDTOs_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "ProfileDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    СriterionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementGroup_Сriterion_СriterionId",
                        column: x => x.СriterionId,
                        principalTable: "Сriterion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DataType = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true),
                    MinValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    RequirementGroupId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirement_RequirementGroup_RequirementGroupId",
                        column: x => x.RequirementGroupId,
                        principalTable: "RequirementGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requirement_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VendorDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ClassificationId = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProcuringEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDTOs_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Hash = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    DatePublished = table.Column<string>(type: "TEXT", nullable: false),
                    VendorDTOId = table.Column<string>(type: "TEXT", nullable: true),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    LegalName = table.Column<string>(type: "TEXT", nullable: false),
                    Scheme = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcuringEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactPointId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentifierId = table.Column<string>(type: "TEXT", nullable: false),
                    Kind = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcuringEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcuringEntity_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcuringEntity_ContactPoint_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcuringEntity_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedProfile = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ClassificationId = table.Column<string>(type: "TEXT", nullable: false),
                    IdentifierId = table.Column<string>(type: "TEXT", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDTOs_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDTOs_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDTOs_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDTOs_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Scale = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactPointId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentifierId = table.Column<string>(type: "TEXT", nullable: false),
                    OfferDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_ContactPoint_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_OfferDTOs_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "OfferDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactPointId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentifierId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendor_ContactPoint_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendor_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sizes = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryDTOId = table.Column<string>(type: "TEXT", nullable: true),
                    ProductDTOId = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_CategoryDTOs_CategoryDTOId",
                        column: x => x.CategoryDTOId,
                        principalTable: "CategoryDTOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_ProductDTOs_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "ProductDTOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_ProfileDTOs_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "ProfileDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Requirement = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDTOId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementResponse_ProductDTOs_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "ProductDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VendorId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActivated = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    DateModified = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorDTOs_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сriterion_ProfileDTOId",
                table: "Сriterion",
                column: "ProfileDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAddress_OfferDTOId",
                table: "BaseAddress",
                column: "OfferDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_VendorDTOId",
                table: "Category",
                column: "VendorDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDTOs_ClassificationId",
                table: "CategoryDTOs",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDTOs_ProcuringEntityId",
                table: "CategoryDTOs",
                column: "ProcuringEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_VendorDTOId",
                table: "Document",
                column: "VendorDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_ProductDTOId",
                table: "Identifiers",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CategoryDTOId",
                table: "Image",
                column: "CategoryDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductDTOId",
                table: "Image",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProfileDTOId",
                table: "Image",
                column: "ProfileDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDTOs_MinOrderValueId",
                table: "OfferDTOs",
                column: "MinOrderValueId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDTOs_ValueId",
                table: "OfferDTOs",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcuringEntity_AddressId",
                table: "ProcuringEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcuringEntity_ContactPointId",
                table: "ProcuringEntity",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcuringEntity_IdentifierId",
                table: "ProcuringEntity",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDTOs_BrandId",
                table: "ProductDTOs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDTOs_ClassificationId",
                table: "ProductDTOs",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDTOs_IdentifierId",
                table: "ProductDTOs",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDTOs_ProductId",
                table: "ProductDTOs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDTOs_ClassificationId",
                table: "ProfileDTOs",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDTOs_UnitId",
                table: "ProfileDTOs",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDTOs_ValueId",
                table: "ProfileDTOs",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_RequirementGroupId",
                table: "Requirement",
                column: "RequirementGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_UnitId",
                table: "Requirement",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementGroup_СriterionId",
                table: "RequirementGroup",
                column: "СriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementResponse_ProductDTOId",
                table: "RequirementResponse",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactPointId",
                table: "Supplier",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_IdentifierId",
                table: "Supplier",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_OfferDTOId",
                table: "Supplier",
                column: "OfferDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_AddressId",
                table: "Vendor",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_ContactPointId",
                table: "Vendor",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_IdentifierId",
                table: "Vendor",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorDTOs_VendorId",
                table: "VendorDTOs",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_VendorDTOs_VendorDTOId",
                table: "Category",
                column: "VendorDTOId",
                principalTable: "VendorDTOs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDTOs_ProcuringEntity_ProcuringEntityId",
                table: "CategoryDTOs",
                column: "ProcuringEntityId",
                principalTable: "ProcuringEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_VendorDTOs_VendorDTOId",
                table: "Document",
                column: "VendorDTOId",
                principalTable: "VendorDTOs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_ProductDTOs_ProductDTOId",
                table: "Identifiers",
                column: "ProductDTOId",
                principalTable: "ProductDTOs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDTOs_Classifications_ClassificationId",
                table: "ProductDTOs");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_ProductDTOs_ProductDTOId",
                table: "Identifiers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "RequirementResponse");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "VendorDTOs");

            migrationBuilder.DropTable(
                name: "CategoryDTOs");

            migrationBuilder.DropTable(
                name: "RequirementGroup");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "ProcuringEntity");

            migrationBuilder.DropTable(
                name: "Сriterion");

            migrationBuilder.DropTable(
                name: "BaseAddress");

            migrationBuilder.DropTable(
                name: "ContactPoint");

            migrationBuilder.DropTable(
                name: "ProfileDTOs");

            migrationBuilder.DropTable(
                name: "OfferDTOs");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "MinOrderValue");

            migrationBuilder.DropTable(
                name: "Value");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "ProductDTOs");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
