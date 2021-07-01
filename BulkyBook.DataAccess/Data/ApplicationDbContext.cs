using System;
using System.Collections.Generic;
using System.Text;
using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<BusinessHour> BusienssHour { get; set; }
        public DbSet<BusinessCategory> BusinessCategory { get; set; }
        public DbSet<BusinessCertification> BusinessCertification { get; set; }
        public DbSet<BusinessImage> BusinessImage { get; set; }
        public DbSet<BusinessKeyword> BusinessKeyword { get; set; }
        public DbSet<BusinessPaymentMode> BusinessPaymentMode { get; set; }
        public DbSet<BusinessService> BusinessService { get; set; }
        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<Favourite> Favourite { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageDuration> PackageDuration { get; set; }
        public DbSet<PaymentMode> PaymentMode { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<UserPackage> UserPackage { get; set; }
        public DbSet<UserPrivate> UserPrivate { get; set; }



        public DbSet<Address> AddressTables { get; set; }
        public DbSet<Email> EmailTables { get; set; }
        public DbSet<Landline> LandlineTables { get; set; }
        public DbSet<Location> LocationTables { get; set; }
        public DbSet<Mobile> MobileTables { get; set; }
        public DbSet<Social> SocialTables { get; set; }



        public DbSet<ReviewRating> ReviewRatings { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Helpful> Helpfuls { get; set; }
        public DbSet<ReportAbuse> ReportAbuses { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<FAQHelpful> FAQHelpfuls { get; set; }
        public DbSet<FAQReportAbuse> FAQReportAbuses { get; set; }

        public DbSet<Category> PrimaryCategory { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Promotionimage> Promotionimage { get; set; }


        public DbSet<Reportasinaccurate> Reportasinaccurates { get; set; }

        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<TechnicalService> TechnicalServices { get; set; }
        public DbSet<Retail> Retails { get; set; }
        public DbSet<Fitness> Fitness { get; set; }
        public DbSet<ProfessionalAssistance> ProfessionalAssistances { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Event> Events { get; set; }

        //public DbSet<Hospital> Hospital { get; set; }
        //public DbSet<Nursing> Nursing { get; set; }
        //public DbSet<Ambulatory> Ambulatory { get; set; }
        //public DbSet<MedicalPractitioner> MedicalPractitioner { get; set; }
        //public DbSet<TestingLab> TestingLab { get; set; }
        //public DbSet<MedicalDeviceVendor> MedicalDeviceVendor { get; set; }
        //public DbSet<MedicalInsurance> MedicalInsurance { get; set; }
        //public DbSet<Pharmaceutical> Pharmaceutical { get; set; }
        public DbSet<HealthCare> HealthCare { get; set; }
        public DbSet<BusinessEmployee> BusinessEmployee { get; set; }

        public DbSet<HospitalDepartment> Hospitaldepartments { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Facility> Facility { get; set; }
        public DbSet<BusinessLanguage> BusinessLanguage { get; set; }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<NewAddress> Address { get; set; }

        public DbSet<Designation> Designation { get; set; }
        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<AmbulatoryType> AmbulatoryType { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<HospitalType> HospitalType { get; set; }
        public DbSet<MedicalInsuranceType> MedicalInsuranceType { get; set; }
        public DbSet<MedicalSuppliesType> MedicalSuppliesType { get; set; }
        public DbSet<NursingType> NursingType { get; set; }
        public DbSet<PharmaceuticalType> PharmaceuticalType { get; set; }
        public DbSet<TestingLabType> TestingLabType { get; set; }

        public DbSet<HealthcareBranch> HealthcareBranch { get; set; }
        public DbSet<HealthcareDoctor> HealthcareDoctor { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<DoctorLanguage> DoctorLanguage { get; set; }
        public DbSet<State> State  { get; set; }
        public DbSet<District> District { get; set; }

        public DbSet<Count> Count { get; set; }


    }
}


