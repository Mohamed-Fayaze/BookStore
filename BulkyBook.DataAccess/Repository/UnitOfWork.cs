using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CoverType = new CoverTypeRepository(_db);
            Business = new BusinessRepository(_db);
            Product = new ProductRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            SP_Call = new SP_Call(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            BusinessType = new BusinessTypeRepository(_db);
            PaymentMode = new PaymentModeRepository(_db);
            Services = new ServicesRepository(_db);
            UserPrivate = new UserPrivateRepository(_db);
            BusinessKeyword = new BusinessKeywordRepository(_db);
            Preference = new PrefereceRepository(_db);
            BusinessService = new BusinessServiceRepository(_db);
            BusinessHour = new BusinessHourRepository(_db);
            BusinessCertification = new BusinessCertificationRepository(_db);
            BusinessPaymentMode = new BusinessPaymentModeRepository(_db);
            BusinessImage = new BusinessImageRepository(_db);
            Favourite = new FavouriteRepository(_db);
            ReviewRating = new ReviewRatingRepository(_db);
            Other = new OtherRepository(_db);
            ReportAbuse = new ReportAbuseRepository(_db);
            Helpful = new HelpfulRepository(_db);
            FAQ = new FAQRepository(_db);
            FAQReportAbuse = new FAQReportAbuseRepository(_db);
            FAQHelpful = new FAQHelpfulRepository(_db);
            //address
            Address = new AddressRepository(_db);
            Mobile = new MobileRepository(_db);
            Email = new EmailRepository(_db);
            Landline = new LandlineRepository(_db);
            Location = new LocationRepository(_db);
            Social = new SocialRepository(_db);

            //Category
            Category = new CategoryRepository(_db);
            SubCategory = new SubCategoryRepository(_db);

            //Promotion
            Promotion = new PromotionRepository(_db);
            Promotionimage = new PromotionimageRepository(_db);

            //Enquiry
            Enquiry = new EnquiryRepository(_db);

            Reportasinaccurate = new ReportasinaccurateRepository(_db);

            //Automobile
            Automobile = new AutomobileRepository(_db);

            //Fitness
            Fitness = new FitnessRepository(_db);

            //TechnicalService
            TechnicalService = new TechnicalServiceRepository(_db);

            //Retail
            Retail = new RetailRepository(_db);

            //ProfessionalAssistance
            ProfessionalAssistance = new ProfessionalAssistanceRepository(_db);

            //Restaurant
            Restaurant = new RestaurantRepository(_db);

            //Hotels
            Hotels = new HotelsRepository(_db);

            //Event
            Event = new EventRepository(_db);

            //HealthCare
            HealthCare = new HealthCareRepository(_db);
            //Nursing = new NursingRepository(_db);
            //Ambulatory = new AmbulatoryRepository(_db);
            //MedicalPractitioner = new MedicalPractitionerRepository(_db);
            //TestingLab = new TestingLabRepository(_db);
            //MedicalDeviceVendor = new MedicalDeviceVendorRepository(_db);
            //MedicalInsurance = new MedicalInsuranceRepository(_db);
            //Pharmaceutical = new PharmaceuticalRepository(_db);
            BusinessLanguage = new BusinessLanguageRepository(_db);

            //content

            Hospitaldepartment = new HospitaldepartmentRepository(_db);
            Language = new LanguageRepository(_db);
            IndustryType = new IndustryTypeRepository(_db);
            Speciality = new SpecialityRepository(_db);
            Facility = new FacilityRepository(_db);


            //contact
            Contact = new ContactRepository(_db);
            //Location = new LocationRepository(_db);

            BusinessEmployee = new BusinessEmployeeRepository(_db);

            Designation = new DesignationRepository(_db);

            Qualification = new QualificationRepository(_db);

            AmbulatoryType = new AmbulatoryTypeRepository(_db);

            EmployeeType = new EmployeeTypeRepository(_db);

            HospitalType = new HospitalTypeRepository(_db);

            MedicalInsuranceType = new MedicalInsuranceTypeRepository(_db);

            MedicalSuppliesType = new MedicalSuppliesTypeRepository(_db);

            NursingType = new NursingTypeRepository(_db);

            PharmaceuticalType = new PharmaceuticalTypeRepository(_db);

            TestingLabType = new TestingLabTypeRepository(_db);

            HealthcareBranch = new HealthcareBranchRepository(_db);

            HealthcareDoctor = new HealthcareDoctorRepository(_db);

            Nationality = new NationalityRepository(_db);
            DoctorLanguage = new DoctorLanguageRepository(_db);

            State = new StateRepository(_db);
            District = new DistrictRepository(_db);

            Count = new CountRepository(_db);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IBusinessRepository Business { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IBusinessTypeRepository BusinessType { get; private set; }
        public IPaymentModeRepository PaymentMode { get; private set; }
        public IServicesRepository Services { get; private set; }
        public IUserPrivateRepository UserPrivate { get; private set; }
        public IBusinessKeywordRepository BusinessKeyword { get; private set; }
        public IPreferenceRepository Preference { get; private set; }
        public IBusinessServiceRepository BusinessService { get; private set; }
        public IBusinessHourRepository BusinessHour { get; private set; }
        public IBusinessCertificationRepository BusinessCertification { get; private set; }
        public IBusinessPaymentModeRepository BusinessPaymentMode { get; private set; }
        public IBusinessImageRepository BusinessImage { get; private set; }
        public IFavouriteRepository Favourite { get; private set; }
        public IReviewRatingRepository ReviewRating { get; private set; }
        public IOtherRepository Other { get; private set; }
        public IReportAbuseRepository ReportAbuse { get; private set; }
        public IHelpfulRepository Helpful { get; private set; }
        public IFAQRepository FAQ { get; private set; }
        public IFAQReportAbuseRepository FAQReportAbuse { get; private set; }
        public IFAQHelpfulRepository FAQHelpful { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        //address 
        public IAddressRepository Address { get; private set; }
        public IMobileRepository Mobile { get; private set; }
        public IEmailRepository Email { get; private set; }
        public ILandlineRepository Landline { get; private set; }
        public ISocialRepository Social { get; private set; }
        public ILocationRepository Location { get; private set; }

        //Category
        public ICategoryRepository Category { get; private set; }
        public ISubCategoryRepository SubCategory { get; private set; }

        //Promotion
        public IPromotionRepository Promotion { get; private set; }
        public IPromotionimageRepository Promotionimage { get; private set; }

        //Enquiry
        public IEnquiryRepository Enquiry { get; private set; }

        public IReportasinaccurateRepository Reportasinaccurate { get; private set; }

        //Automobile
        public IAutomobileRepository Automobile { get; private set; }

        //Fitness
        public IFitnessRepository Fitness { get; private set; }

        //TechnicalService
        public ITechnicalServiceRepository TechnicalService { get; private set; }

        //Retail
        public IRetailRepository Retail { get; private set; }

        //ProfessionalAssistance
        public IProfessionalAssistanceRepository ProfessionalAssistance { get; private set; }

        //Restaurant
        public IRestaurantRepository Restaurant { get; private set; }

        //Hotels
        public IHotelsRepository Hotels { get; private set; }

        //Event
        public IEventRepository Event { get; private set; }

        //HealthCare
        public IHealthCareRepository HealthCare { get; private set; }
        //public INursingRepository Nursing { get; private set; }
        //public IAmbulatoryRepository Ambulatory { get; private set; }
        //public IMedicalPractitionerRepository MedicalPractitioner { get; private set; }
        //public ITestingLabRepository TestingLab { get; private set; }
        //public IMedicalDeviceVendorRepository MedicalDeviceVendor { get; private set; }
        //public IMedicalInsuranceRepository MedicalInsurance { get; private set; }
        //public IPharmaceuticalRepository Pharmaceutical { get; private set; }
        public IBusinessLanguageRepository BusinessLanguage { get; private set; }

        //content
        public IHospitaldepartmentRepository Hospitaldepartment { get; private set; }
        public ILanguageRepository Language { get; private set; }
        public IIndustryTypeRepository IndustryType { get; private set; }
        public ISpecialityRepository Speciality { get; private set; }
        public IFacilityRepository Facility { get; private set; }

        //Contact
        public IContactRepository Contact { get; private set; }

        public IBusinessEmployeeRepository BusinessEmployee { get; private set; }

        public IDesignationRepository Designation { get; private set; }

        public IQualificationRepository Qualification { get; private set; }

        public IAmbulatoryTypeRepository AmbulatoryType { get; private set; }

        public IEmployeeTypeRepository EmployeeType { get; private set; }

        public IHospitalTypeRepository HospitalType { get; private set; }

        public IMedicalInsuranceTypeRepository MedicalInsuranceType { get; private set; }

        public IMedicalSuppliesTypeRepository MedicalSuppliesType { get; private set; }

        public INursingTypeRepository NursingType { get; private set; }

        public IPharmaceuticalTypeRepository PharmaceuticalType { get; private set; }

        public ITestingLabTypeRepository TestingLabType { get; private set; }

        public IHealthcareDoctorRepository HealthcareDoctor { get; private set; }

        public IHealthcareBranchRepository HealthcareBranch { get; private set; }

        public INationalityRepository Nationality { get; private set; }
        public IDoctorLanguageRepository DoctorLanguage { get; private set; }

        public IStateRepository State { get; set; }
        public IDistrictRepository District { get; set; }

        public ICountRepository Count { get; set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
        //public bool Savethis()
        //{
        //    return _db.SaveChanges() > 0;
        //}



    }
}
