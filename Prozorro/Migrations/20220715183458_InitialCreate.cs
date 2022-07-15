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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinOrderValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinOrderValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueAddetTaxIncluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RelatedProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false),
                    MinOrderValueId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_MinOrderValue_MinOrderValueId",
                        column: x => x.MinOrderValueId,
                        principalTable: "MinOrderValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Value_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassificationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatedCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Value_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAddress_Offers_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Сriterion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сriterion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сriterion_Profiles_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    СriterionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequirementGroupId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassificationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcuringEntityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identifier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcuringEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ContactPointId = table.Column<int>(type: "int", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_ProcuringEntity_Identifier_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatedProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Identifier_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ContactPointId = table.Column<int>(type: "int", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OfferDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_Supplier_Identifier_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supplier_Offers_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ContactPointId = table.Column<int>(type: "int", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_Vendor_Identifier_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfileDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Categories_CategoryDTOId",
                        column: x => x.CategoryDTOId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Profiles_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementResponse_Products_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Vendor_VendorId",
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
                name: "IX_Categories_ClassificationId",
                table: "Categories",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProcuringEntityId",
                table: "Categories",
                column: "ProcuringEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_VendorDTOId",
                table: "Category",
                column: "VendorDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_VendorDTOId",
                table: "Document",
                column: "VendorDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifier_ProductDTOId",
                table: "Identifier",
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
                name: "IX_Offers_MinOrderValueId",
                table: "Offers",
                column: "MinOrderValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ValueId",
                table: "Offers",
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
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClassificationId",
                table: "Products",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdentifierId",
                table: "Products",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ClassificationId",
                table: "Profiles",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UnitId",
                table: "Profiles",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ValueId",
                table: "Profiles",
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
                name: "IX_Vendors_VendorId",
                table: "Vendors",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProcuringEntity_ProcuringEntityId",
                table: "Categories",
                column: "ProcuringEntityId",
                principalTable: "ProcuringEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Vendors_VendorDTOId",
                table: "Category",
                column: "VendorDTOId",
                principalTable: "Vendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Vendors_VendorDTOId",
                table: "Document",
                column: "VendorDTOId",
                principalTable: "Vendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identifier_Products_ProductDTOId",
                table: "Identifier",
                column: "ProductDTOId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Classification_ClassificationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Identifier_Products_ProductDTOId",
                table: "Identifier");

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
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Categories");

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
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "MinOrderValue");

            migrationBuilder.DropTable(
                name: "Value");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Identifier");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
