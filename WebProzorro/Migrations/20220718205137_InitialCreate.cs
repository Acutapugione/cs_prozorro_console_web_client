using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProzorro.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoints",
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
                    table.PrimaryKey("PK_ContactPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinOrderValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinOrderValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
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
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferDTOs",
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
                    table.PrimaryKey("PK_OfferDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDTOs_Values_MinOrderValueId",
                        column: x => x.MinOrderValueId,
                        principalTable: "Values",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferDTOs_Values_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassificationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_ProfileDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDTOs_Values_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Values",
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
                        name: "FK_BaseAddress_OfferDTOs_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "OfferDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Сriterions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сriterions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сriterions_ProfileDTOs_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "ProfileDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    СriterionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementGroups_Сriterions_СriterionId",
                        column: x => x.СriterionId,
                        principalTable: "Сriterions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
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
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_RequirementGroups_RequirementGroupId",
                        column: x => x.RequirementGroupId,
                        principalTable: "RequirementGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requirements_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDTOs",
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
                    table.PrimaryKey("PK_CategoryDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDTOs_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcuringEntities",
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
                    table.PrimaryKey("PK_ProcuringEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcuringEntities_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcuringEntities_ContactPoints_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcuringEntities_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatedProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDTOs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
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
                        name: "FK_ProductDTOs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ContactPointId = table.Column<int>(type: "int", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferDTOId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_ContactPoints_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_OfferDTOs_OfferDTOId",
                        column: x => x.OfferDTOId,
                        principalTable: "OfferDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ContactPointId = table.Column<int>(type: "int", nullable: false),
                    IdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_BaseAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendors_ContactPoints_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendors_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
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
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_CategoryDTOs_CategoryDTOId",
                        column: x => x.CategoryDTOId,
                        principalTable: "CategoryDTOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ProductDTOs_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "ProductDTOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ProfileDTOs_ProfileDTOId",
                        column: x => x.ProfileDTOId,
                        principalTable: "ProfileDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequirementResponses",
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
                    table.PrimaryKey("PK_RequirementResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementResponses_ProductDTOs_ProductDTOId",
                        column: x => x.ProductDTOId,
                        principalTable: "ProductDTOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorDTOs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorDTOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorDTOs_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сriterions_ProfileDTOId",
                table: "Сriterions",
                column: "ProfileDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAddress_OfferDTOId",
                table: "BaseAddress",
                column: "OfferDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_VendorDTOId",
                table: "Categories",
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
                name: "IX_Documents_VendorDTOId",
                table: "Documents",
                column: "VendorDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_ProductDTOId",
                table: "Identifiers",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryDTOId",
                table: "Images",
                column: "CategoryDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductDTOId",
                table: "Images",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProfileDTOId",
                table: "Images",
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
                name: "IX_ProcuringEntities_AddressId",
                table: "ProcuringEntities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcuringEntities_ContactPointId",
                table: "ProcuringEntities",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcuringEntities_IdentifierId",
                table: "ProcuringEntities",
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
                name: "IX_RequirementGroups_СriterionId",
                table: "RequirementGroups",
                column: "СriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementResponses_ProductDTOId",
                table: "RequirementResponses",
                column: "ProductDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_RequirementGroupId",
                table: "Requirements",
                column: "RequirementGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_UnitId",
                table: "Requirements",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ContactPointId",
                table: "Suppliers",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_IdentifierId",
                table: "Suppliers",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_OfferDTOId",
                table: "Suppliers",
                column: "OfferDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorDTOs_VendorId",
                table: "VendorDTOs",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_AddressId",
                table: "Vendors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ContactPointId",
                table: "Vendors",
                column: "ContactPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_IdentifierId",
                table: "Vendors",
                column: "IdentifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_VendorDTOs_VendorDTOId",
                table: "Categories",
                column: "VendorDTOId",
                principalTable: "VendorDTOs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDTOs_ProcuringEntities_ProcuringEntityId",
                table: "CategoryDTOs",
                column: "ProcuringEntityId",
                principalTable: "ProcuringEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_VendorDTOs_VendorDTOId",
                table: "Documents",
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MinOrderValues");

            migrationBuilder.DropTable(
                name: "RequirementResponses");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "VendorDTOs");

            migrationBuilder.DropTable(
                name: "CategoryDTOs");

            migrationBuilder.DropTable(
                name: "RequirementGroups");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "ProcuringEntities");

            migrationBuilder.DropTable(
                name: "Сriterions");

            migrationBuilder.DropTable(
                name: "BaseAddress");

            migrationBuilder.DropTable(
                name: "ContactPoints");

            migrationBuilder.DropTable(
                name: "ProfileDTOs");

            migrationBuilder.DropTable(
                name: "OfferDTOs");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "ProductDTOs");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
