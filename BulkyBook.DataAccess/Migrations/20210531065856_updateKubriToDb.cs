using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class updateKubriToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmbulatoryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulatoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryIcon = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryImage = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Image = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitaldepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitaldepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndustryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryTypeName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalInsuranceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInsuranceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSuppliesType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSuppliesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NursingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaceuticalType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaceuticalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestingLabType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingLabType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 120, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designation_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SecondaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondaryName = table.Column<string>(maxLength: 120, nullable: true),
                    SubCategoryIcon = table.Column<string>(maxLength: 200, nullable: true),
                    SubCategoryImage = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SecondaryId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    ListPrice = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Price50 = table.Column<double>(nullable: false),
                    Price100 = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CoverTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageDuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(nullable: false),
                    DurationType = table.Column<string>(maxLength: 100, nullable: false),
                    DurationPeriod = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDuration_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    YearOfEstablishment = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    WebsiteURL = table.Column<string>(maxLength: 120, nullable: true),
                    isFullDayAvailable = table.Column<bool>(nullable: false),
                    FromWorkingHour = table.Column<TimeSpan>(nullable: true),
                    ToWorkingHour = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCare_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SecondaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthcareBranch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    HealthcareId = table.Column<int>(nullable: false),
                    HospitalTypeId = table.Column<int>(nullable: true),
                    TestingLabTypeId = table.Column<int>(nullable: true),
                    NursingTypeId = table.Column<int>(nullable: true),
                    AmbulatoryTypeId = table.Column<int>(nullable: true),
                    MedicalSuppliesTypeId = table.Column<int>(nullable: true),
                    MedicalInsuranceTypeId = table.Column<int>(nullable: true),
                    PharmaceuticalTypeId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    FacilityId = table.Column<int>(nullable: true),
                    ContactPersonName = table.Column<string>(maxLength: 60, nullable: false),
                    ContactNo1 = table.Column<string>(maxLength: 15, nullable: false),
                    ContactNo2 = table.Column<string>(maxLength: 15, nullable: true),
                    EmergencyContactNo = table.Column<string>(maxLength: 15, nullable: false),
                    SocialMediaName = table.Column<string>(maxLength: 30, nullable: true),
                    SocialMediaURL = table.Column<string>(maxLength: 120, nullable: true),
                    Address = table.Column<string>(maxLength: 120, nullable: false),
                    City = table.Column<string>(maxLength: 120, nullable: true),
                    UploadImage = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_AmbulatoryType_AmbulatoryTypeId",
                        column: x => x.AmbulatoryTypeId,
                        principalTable: "AmbulatoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_Hospitaldepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Hospitaldepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_HealthCare_HealthcareId",
                        column: x => x.HealthcareId,
                        principalTable: "HealthCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_HospitalType_HospitalTypeId",
                        column: x => x.HospitalTypeId,
                        principalTable: "HospitalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_MedicalInsuranceType_MedicalInsuranceTypeId",
                        column: x => x.MedicalInsuranceTypeId,
                        principalTable: "MedicalInsuranceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_MedicalSuppliesType_MedicalSuppliesTypeId",
                        column: x => x.MedicalSuppliesTypeId,
                        principalTable: "MedicalSuppliesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_NursingType_NursingTypeId",
                        column: x => x.NursingTypeId,
                        principalTable: "NursingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_PharmaceuticalType_PharmaceuticalTypeId",
                        column: x => x.PharmaceuticalTypeId,
                        principalTable: "PharmaceuticalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareBranch_TestingLabType_TestingLabTypeId",
                        column: x => x.TestingLabTypeId,
                        principalTable: "TestingLabType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthcareDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    DoctorTypeId = table.Column<int>(nullable: false),
                    SpecialityId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    SundayFrom = table.Column<TimeSpan>(nullable: true),
                    SundayTo = table.Column<TimeSpan>(nullable: true),
                    MondayFrom = table.Column<TimeSpan>(nullable: true),
                    MondayTo = table.Column<TimeSpan>(nullable: true),
                    TuesdayFrom = table.Column<TimeSpan>(nullable: true),
                    TuesdayTo = table.Column<TimeSpan>(nullable: true),
                    WednesdayFrom = table.Column<TimeSpan>(nullable: true),
                    WednesdayTo = table.Column<TimeSpan>(nullable: true),
                    ThrusdayFrom = table.Column<TimeSpan>(nullable: true),
                    ThrusdayTo = table.Column<TimeSpan>(nullable: true),
                    FridayFrom = table.Column<TimeSpan>(nullable: true),
                    FridayTo = table.Column<TimeSpan>(nullable: true),
                    SaturdayFrom = table.Column<TimeSpan>(nullable: true),
                    SaturdayTo = table.Column<TimeSpan>(nullable: true),
                    DoctorPhoto = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_HealthcareBranch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "HealthcareBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_EmployeeType_DoctorTypeId",
                        column: x => x.DoctorTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcareDoctor_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    PhotoUrl = table.Column<string>(maxLength: 200, nullable: true),
                    DesignationId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTables",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTables", x => x.EmailAddressId);
                });

            migrationBuilder.CreateTable(
                name: "LandlineTables",
                columns: table => new
                {
                    LandlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    LandlineNo = table.Column<string>(maxLength: 14, nullable: true),
                    Isprimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlineTables", x => x.LandlineId);
                });

            migrationBuilder.CreateTable(
                name: "LocationTables",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(maxLength: 200, nullable: true),
                    Longitude = table.Column<string>(maxLength: 200, nullable: true),
                    Website = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTables", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "MobileTables",
                columns: table => new
                {
                    MobileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTables", x => x.MobileId);
                });

            migrationBuilder.CreateTable(
                name: "SocialTables",
                columns: table => new
                {
                    SocialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    SocialType = table.Column<string>(nullable: true),
                    SocialLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialTables", x => x.SocialId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    DoorNo = table.Column<string>(maxLength: 10, nullable: true),
                    Street = table.Column<string>(maxLength: 60, nullable: true),
                    Area = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 60, nullable: true),
                    State = table.Column<string>(maxLength: 60, nullable: true),
                    Country = table.Column<string>(maxLength: 60, nullable: true),
                    Website = table.Column<string>(maxLength: 200, nullable: true),
                    Latitude = table.Column<string>(maxLength: 200, nullable: true),
                    Longitude = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressTables",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    HouseNo = table.Column<string>(maxLength: 10, nullable: false),
                    AddressField = table.Column<string>(maxLength: 60, nullable: false),
                    AreaStreet = table.Column<string>(maxLength: 60, nullable: false),
                    CityTown = table.Column<string>(maxLength: 60, nullable: false),
                    StateProvinceRegion = table.Column<string>(maxLength: 60, nullable: false),
                    Country = table.Column<string>(maxLength: 60, nullable: false),
                    Pincode = table.Column<string>(maxLength: 6, nullable: false),
                    Landmark = table.Column<string>(maxLength: 60, nullable: false),
                    AddressType = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTables", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    Brand = table.Column<string>(maxLength: 150, nullable: true),
                    ServiceType = table.Column<string>(maxLength: 200, nullable: true),
                    Mobilemechanic = table.Column<bool>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentCorporation = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessTypeId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: true),
                    ProfilePhoto = table.Column<string>(maxLength: 200, nullable: true),
                    YearOfRegistered = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsVerified = table.Column<bool>(nullable: true),
                    VerifiedStatus = table.Column<string>(maxLength: 30, nullable: true),
                    RejectedReason = table.Column<string>(maxLength: 100, nullable: true),
                    ApprovedBy = table.Column<string>(maxLength: 120, nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastOperation = table.Column<string>(nullable: false),
                    LastOperationOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Business_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Business_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SecondaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    ProfilePhoto = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: true),
                    VerifiedStatus = table.Column<string>(maxLength: 30, nullable: true),
                    RejectedReason = table.Column<string>(maxLength: 100, nullable: true),
                    ApprovedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Business_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusienssHour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    SundayFrom = table.Column<TimeSpan>(nullable: true),
                    SundayTo = table.Column<TimeSpan>(nullable: true),
                    MondayFrom = table.Column<TimeSpan>(nullable: true),
                    MondayTo = table.Column<TimeSpan>(nullable: true),
                    TuesdayFrom = table.Column<TimeSpan>(nullable: true),
                    TuesdayTo = table.Column<TimeSpan>(nullable: true),
                    WednesdayFrom = table.Column<TimeSpan>(nullable: true),
                    WednesdayTo = table.Column<TimeSpan>(nullable: true),
                    ThrusdayFrom = table.Column<TimeSpan>(nullable: true),
                    ThrusdayTo = table.Column<TimeSpan>(nullable: true),
                    FridayFrom = table.Column<TimeSpan>(nullable: true),
                    FridayTo = table.Column<TimeSpan>(nullable: true),
                    SaturdayFrom = table.Column<TimeSpan>(nullable: true),
                    SaturdayTo = table.Column<TimeSpan>(nullable: true),
                    SundayFrom1 = table.Column<TimeSpan>(nullable: true),
                    SundayTo1 = table.Column<TimeSpan>(nullable: true),
                    MondayFrom1 = table.Column<TimeSpan>(nullable: true),
                    MondayTo1 = table.Column<TimeSpan>(nullable: true),
                    TuesdayFrom1 = table.Column<TimeSpan>(nullable: true),
                    TuesdayTo1 = table.Column<TimeSpan>(nullable: true),
                    WednesdayFrom1 = table.Column<TimeSpan>(nullable: true),
                    WednesdayTo1 = table.Column<TimeSpan>(nullable: true),
                    ThrusdayFrom1 = table.Column<TimeSpan>(nullable: true),
                    ThrusdayTo1 = table.Column<TimeSpan>(nullable: true),
                    FridayFrom1 = table.Column<TimeSpan>(nullable: true),
                    FridayTo1 = table.Column<TimeSpan>(nullable: true),
                    SaturdayFrom1 = table.Column<TimeSpan>(nullable: true),
                    SaturdayTo1 = table.Column<TimeSpan>(nullable: true),
                    IsDualTimings = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusienssHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusienssHour_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<string>(maxLength: 100, nullable: true),
                    OtherCategoryId = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCertification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    Certificate = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCertification_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessImage_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessKeyword",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessKeyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessKeyword_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessLanguage_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessLanguage_Languages_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPaymentMode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    PaymentModeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPaymentMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPaymentMode_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessPaymentMode_PaymentMode_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "PaymentMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    ServicesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessService_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessService_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: true),
                    ContactPersonName = table.Column<string>(maxLength: 60, nullable: true),
                    ContactNumber = table.Column<string>(maxLength: 14, nullable: true),
                    EmergencyContactNumber = table.Column<string>(maxLength: 14, nullable: true),
                    Website = table.Column<string>(maxLength: 60, nullable: true),
                    SocialName = table.Column<string>(maxLength: 60, nullable: true),
                    SocialURL = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    OldPrice = table.Column<int>(nullable: false),
                    OfferPrice = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PromoDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquiry_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiry_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offer = table.Column<string>(maxLength: 200, nullable: true),
                    Totalmembers = table.Column<int>(nullable: false),
                    OrganizerName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Timing = table.Column<DateTime>(nullable: false),
                    Fees = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 200, nullable: true),
                    SubType = table.Column<string>(maxLength: 200, nullable: true),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    Paymentmode = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    FAQQuestion = table.Column<string>(maxLength: 300, nullable: false),
                    FAQAnswer = table.Column<string>(maxLength: 300, nullable: true),
                    FAQHelpfulCount = table.Column<int>(nullable: true),
                    QuestionOn = table.Column<DateTime>(nullable: false),
                    AnswerOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAQs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourite_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fitness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minprice = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Mode = table.Column<string>(maxLength: 100, nullable: true),
                    FitnessType = table.Column<string>(nullable: true),
                    Traineravailable = table.Column<bool>(nullable: false),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fitness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fitness_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fitness_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200, nullable: true),
                    Minprice = table.Column<string>(maxLength: 100, nullable: true),
                    Paymentmode = table.Column<string>(maxLength: 200, nullable: true),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    Hotelclass = table.Column<int>(nullable: false),
                    style = table.Column<string>(maxLength: 100, nullable: true),
                    Amenities = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    LoginDate = table.Column<DateTime>(nullable: true),
                    LoginTime = table.Column<TimeSpan>(nullable: true),
                    LogoutDate = table.Column<DateTime>(nullable: true),
                    LogoutTime = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Carrier = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Language = table.Column<string>(maxLength: 100, nullable: true),
                    Industry = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preference_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalAssistances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    Modeofservice = table.Column<string>(maxLength: 200, nullable: true),
                    ServiceType = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalAssistances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalAssistances_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessionalAssistances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reportasinaccurates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportasinaccurates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportasinaccurates_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportasinaccurates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Features = table.Column<string>(maxLength: 200, nullable: true),
                    Cuisines = table.Column<string>(maxLength: 200, nullable: true),
                    Meals = table.Column<string>(maxLength: 200, nullable: true),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    DoorDelivery = table.Column<bool>(nullable: false),
                    Amenities = table.Column<string>(maxLength: 200, nullable: true),
                    Dishes = table.Column<string>(maxLength: 200, nullable: true),
                    DietaryRestrictions = table.Column<string>(maxLength: 200, nullable: true),
                    miniprice = table.Column<int>(nullable: false),
                    maxprice = table.Column<int>(nullable: false),
                    GoodFor = table.Column<string>(maxLength: 200, nullable: true),
                    Paymentmode = table.Column<string>(maxLength: 200, nullable: true),
                    Menu = table.Column<string>(maxLength: 200, nullable: true),
                    Gallery = table.Column<string>(maxLength: 200, nullable: true),
                    standard = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Retails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minorder = table.Column<int>(nullable: false),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    DoorDelivery = table.Column<bool>(nullable: false),
                    RetailType = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retails_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Retails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BussinessId = table.Column<int>(nullable: true),
                    OverallRating = table.Column<decimal>(nullable: false),
                    Service = table.Column<decimal>(nullable: true),
                    Valueformoney = table.Column<decimal>(nullable: true),
                    OtherRating = table.Column<decimal>(nullable: true),
                    Image = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ReviewOn = table.Column<DateTime>(nullable: false),
                    Recommendation = table.Column<bool>(nullable: false),
                    HelpfulCount = table.Column<int>(nullable: true),
                    OtherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewRatings_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewRatings_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnlineBooking = table.Column<bool>(nullable: false),
                    DoorService = table.Column<bool>(nullable: false),
                    ServiceType = table.Column<string>(maxLength: 200, nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    BussinessId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalServices_Business_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalServices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PackageDurationId = table.Column<int>(nullable: false),
                    PurchasedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPackage_PackageDuration_PackageDurationId",
                        column: x => x.PackageDurationId,
                        principalTable: "PackageDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPackage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 50, nullable: true),
                    Occupation = table.Column<string>(maxLength: 100, nullable: true),
                    SchoolName = table.Column<string>(maxLength: 200, nullable: true),
                    CollegeName = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    About = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrivate_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotionimage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<string>(nullable: true),
                    PromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotionimage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotionimage_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQHelpfuls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FAQId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQHelpfuls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQHelpfuls_FAQs_FAQId",
                        column: x => x.FAQId,
                        principalTable: "FAQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAQHelpfuls_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQReportAbuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FAQId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQReportAbuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQReportAbuses_FAQs_FAQId",
                        column: x => x.FAQId,
                        principalTable: "FAQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAQReportAbuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helpfuls",
                columns: table => new
                {
                    HelpfulID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ReviewRatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helpfuls", x => x.HelpfulID);
                    table.ForeignKey(
                        name: "FK_Helpfuls_ReviewRatings_ReviewRatingId",
                        column: x => x.ReviewRatingId,
                        principalTable: "ReviewRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Helpfuls_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportAbuses",
                columns: table => new
                {
                    ReportAbuseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ReviewRatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAbuses", x => x.ReportAbuseID);
                    table.ForeignKey(
                        name: "FK_ReportAbuses_ReviewRatings_ReviewRatingId",
                        column: x => x.ReviewRatingId,
                        principalTable: "ReviewRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAbuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BusinessId",
                table: "Address",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTables_BusinessId",
                table: "AddressTables",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTables_UserId",
                table: "AddressTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_BussinessId",
                table: "Automobiles",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_UserId",
                table: "Automobiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusienssHour_BusinessId",
                table: "BusienssHour",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessTypeId",
                table: "Business",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CategoryId",
                table: "Business",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_SubCategoryId",
                table: "Business",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_UserId",
                table: "Business",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategory_BusinessId",
                table: "BusinessCategory",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCertification_BusinessId",
                table: "BusinessCertification",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEmployee_AddressId",
                table: "BusinessEmployee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEmployee_BusinessId",
                table: "BusinessEmployee",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEmployee_UserId",
                table: "BusinessEmployee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImage_BusinessId",
                table: "BusinessImage",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessKeyword_BusinessId",
                table: "BusinessKeyword",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLanguage_BusinessId",
                table: "BusinessLanguage",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLanguage_NationalityId",
                table: "BusinessLanguage",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPaymentMode_BusinessId",
                table: "BusinessPaymentMode",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPaymentMode_PaymentModeId",
                table: "BusinessPaymentMode",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessService_BusinessId",
                table: "BusinessService",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessService_ServicesId",
                table: "BusinessService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_BusinessId",
                table: "Contact",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_CategoryId",
                table: "Designation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTables_AddressId",
                table: "EmailTables",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_BusinessId",
                table: "Enquiry",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_UserId",
                table: "Enquiry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BussinessId",
                table: "Events",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQHelpfuls_FAQId",
                table: "FAQHelpfuls",
                column: "FAQId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQHelpfuls_UserId",
                table: "FAQHelpfuls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQReportAbuses_FAQId",
                table: "FAQReportAbuses",
                column: "FAQId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQReportAbuses_UserId",
                table: "FAQReportAbuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_BussinessId",
                table: "FAQs",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_UserId",
                table: "FAQs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_BusinessId",
                table: "Favourite",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_UserId",
                table: "Favourite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fitness_BussinessId",
                table: "Fitness",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Fitness_UserId",
                table: "Fitness",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCare_SubCategoryId",
                table: "HealthCare",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_AmbulatoryTypeId",
                table: "HealthcareBranch",
                column: "AmbulatoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_DepartmentId",
                table: "HealthcareBranch",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_FacilityId",
                table: "HealthcareBranch",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_HealthcareId",
                table: "HealthcareBranch",
                column: "HealthcareId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_HospitalTypeId",
                table: "HealthcareBranch",
                column: "HospitalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_MedicalInsuranceTypeId",
                table: "HealthcareBranch",
                column: "MedicalInsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_MedicalSuppliesTypeId",
                table: "HealthcareBranch",
                column: "MedicalSuppliesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_NursingTypeId",
                table: "HealthcareBranch",
                column: "NursingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_PharmaceuticalTypeId",
                table: "HealthcareBranch",
                column: "PharmaceuticalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_TestingLabTypeId",
                table: "HealthcareBranch",
                column: "TestingLabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_BranchId",
                table: "HealthcareDoctor",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_DoctorTypeId",
                table: "HealthcareDoctor",
                column: "DoctorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_LanguageId",
                table: "HealthcareDoctor",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_NationalityId",
                table: "HealthcareDoctor",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_QualificationId",
                table: "HealthcareDoctor",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_SpecialityId",
                table: "HealthcareDoctor",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Helpfuls_ReviewRatingId",
                table: "Helpfuls",
                column: "ReviewRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Helpfuls_UserId",
                table: "Helpfuls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_BussinessId",
                table: "Hotels",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LandlineTables_AddressId",
                table: "LandlineTables",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTables_AddressId",
                table: "LocationTables",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserId",
                table: "Log",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTables_AddressId",
                table: "MobileTables",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Others_CategoryId",
                table: "Others",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDuration_PackageId",
                table: "PackageDuration",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_UserId",
                table: "Preference",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CoverTypeId",
                table: "Products",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalAssistances_BussinessId",
                table: "ProfessionalAssistances",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalAssistances_UserId",
                table: "ProfessionalAssistances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotionimage_PromotionId",
                table: "Promotionimage",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BusinessId",
                table: "Promotions",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_BusinessId",
                table: "Report",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAbuses_ReviewRatingId",
                table: "ReportAbuses",
                column: "ReviewRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAbuses_UserId",
                table: "ReportAbuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportasinaccurates_BusinessId",
                table: "Reportasinaccurates",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportasinaccurates_UserId",
                table: "Reportasinaccurates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_BussinessId",
                table: "Restaurants",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Retails_BussinessId",
                table: "Retails",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Retails_UserId",
                table: "Retails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRatings_BussinessId",
                table: "ReviewRatings",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRatings_OtherId",
                table: "ReviewRatings",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRatings_UserId",
                table: "ReviewRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialTables_AddressId",
                table: "SocialTables",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalServices_BussinessId",
                table: "TechnicalServices",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalServices_UserId",
                table: "TechnicalServices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPackage_PackageDurationId",
                table: "UserPackage",
                column: "PackageDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPackage_UserId",
                table: "UserPackage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivate_UserId",
                table: "UserPrivate",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEmployee_Business_BusinessId",
                table: "BusinessEmployee",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEmployee_AspNetUsers_UserId",
                table: "BusinessEmployee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEmployee_AddressTables_AddressId",
                table: "BusinessEmployee",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTables_AddressTables_AddressId",
                table: "EmailTables",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandlineTables_AddressTables_AddressId",
                table: "LandlineTables",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTables_AddressTables_AddressId",
                table: "LocationTables",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileTables_AddressTables_AddressId",
                table: "MobileTables",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialTables_AddressTables_AddressId",
                table: "SocialTables",
                column: "AddressId",
                principalTable: "AddressTables",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Business_BusinessId",
                table: "Address",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTables_Business_BusinessId",
                table: "AddressTables",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTables_AspNetUsers_UserId",
                table: "AddressTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_Business_BussinessId",
                table: "Automobiles",
                column: "BussinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_AspNetUsers_UserId",
                table: "Automobiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_AspNetUsers_UserId",
                table: "Business",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Business_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "BusienssHour");

            migrationBuilder.DropTable(
                name: "BusinessCategory");

            migrationBuilder.DropTable(
                name: "BusinessCertification");

            migrationBuilder.DropTable(
                name: "BusinessEmployee");

            migrationBuilder.DropTable(
                name: "BusinessImage");

            migrationBuilder.DropTable(
                name: "BusinessKeyword");

            migrationBuilder.DropTable(
                name: "BusinessLanguage");

            migrationBuilder.DropTable(
                name: "BusinessPaymentMode");

            migrationBuilder.DropTable(
                name: "BusinessService");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "EmailTables");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "FAQHelpfuls");

            migrationBuilder.DropTable(
                name: "FAQReportAbuses");

            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Fitness");

            migrationBuilder.DropTable(
                name: "HealthcareDoctor");

            migrationBuilder.DropTable(
                name: "Helpfuls");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "IndustryTypes");

            migrationBuilder.DropTable(
                name: "LandlineTables");

            migrationBuilder.DropTable(
                name: "LocationTables");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "MobileTables");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "ProfessionalAssistances");

            migrationBuilder.DropTable(
                name: "Promotionimage");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "ReportAbuses");

            migrationBuilder.DropTable(
                name: "Reportasinaccurates");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Retails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "SocialTables");

            migrationBuilder.DropTable(
                name: "TechnicalServices");

            migrationBuilder.DropTable(
                name: "UserPackage");

            migrationBuilder.DropTable(
                name: "UserPrivate");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PaymentMode");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "HealthcareBranch");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "ReviewRatings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AddressTables");

            migrationBuilder.DropTable(
                name: "PackageDuration");

            migrationBuilder.DropTable(
                name: "AmbulatoryType");

            migrationBuilder.DropTable(
                name: "Hospitaldepartments");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "HealthCare");

            migrationBuilder.DropTable(
                name: "HospitalType");

            migrationBuilder.DropTable(
                name: "MedicalInsuranceType");

            migrationBuilder.DropTable(
                name: "MedicalSuppliesType");

            migrationBuilder.DropTable(
                name: "NursingType");

            migrationBuilder.DropTable(
                name: "PharmaceuticalType");

            migrationBuilder.DropTable(
                name: "TestingLabType");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "BusinessType");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
