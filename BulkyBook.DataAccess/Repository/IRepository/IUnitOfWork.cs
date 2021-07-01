using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        IBusinessRepository Business { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ISP_Call SP_Call { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IBusinessTypeRepository BusinessType { get; }
        IPaymentModeRepository PaymentMode { get; }
        IServicesRepository Services { get; }
        IUserPrivateRepository UserPrivate { get; }
        IBusinessKeywordRepository BusinessKeyword { get; }
        IPreferenceRepository Preference { get; }
        IBusinessServiceRepository BusinessService { get; }
        IBusinessHourRepository BusinessHour { get; }
        IBusinessCertificationRepository BusinessCertification { get; }
        IBusinessPaymentModeRepository BusinessPaymentMode { get; }
        IBusinessImageRepository BusinessImage { get; }
        IFavouriteRepository Favourite { get; }
        IReviewRatingRepository ReviewRating { get; }
        IOtherRepository Other { get; }
        IReportAbuseRepository ReportAbuse { get; }
        IHelpfulRepository Helpful { get; }
        IFAQRepository FAQ { get; }
        IFAQReportAbuseRepository FAQReportAbuse { get; }
        IFAQHelpfulRepository FAQHelpful { get; }
        //address
        IAddressRepository Address { get; }
        IMobileRepository Mobile { get; }

        IEmailRepository Email { get; }
        ILandlineRepository Landline { get; }
        ISocialRepository Social { get; }
        ILocationRepository Location { get; }

        //Category
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }

        //Promotion
        IPromotionRepository Promotion { get; }
        IPromotionimageRepository Promotionimage { get; }

        //Enquiry
        IEnquiryRepository Enquiry { get; }

        //Reportasinaccurate
        IReportasinaccurateRepository Reportasinaccurate { get; }

        //Automobile
        IAutomobileRepository Automobile { get; }

        //Fitness
        IFitnessRepository Fitness { get; }

        //TechnicalService
        ITechnicalServiceRepository TechnicalService { get; }

        //Retail
        IRetailRepository Retail { get; }

        //ProfessionalAssistance
        IProfessionalAssistanceRepository ProfessionalAssistance { get; }

        //Restaurant
        IRestaurantRepository Restaurant { get; }

        //Hotels
        IHotelsRepository Hotels { get; }

        //Event
        IEventRepository Event { get; }

        //HealthCare
        IHealthCareRepository HealthCare { get; }
        //INursingRepository Nursing { get; }
        //IAmbulatoryRepository Ambulatory { get; }
        //IMedicalPractitionerRepository MedicalPractitioner { get; }
        //ITestingLabRepository TestingLab { get; }
        //IMedicalDeviceVendorRepository MedicalDeviceVendor { get; }
        //IMedicalInsuranceRepository MedicalInsurance { get; }
        //IPharmaceuticalRepository Pharmaceutical { get; }
        IBusinessLanguageRepository BusinessLanguage { get; }



        //content
        IHospitaldepartmentRepository Hospitaldepartment { get; }
        ILanguageRepository Language { get; }
        IIndustryTypeRepository IndustryType { get; }
        ISpecialityRepository Speciality { get; }
        IFacilityRepository Facility { get; }


        //Contact
        IContactRepository Contact { get; }
        /*ILocationRepository Location { get; }*/

        IBusinessEmployeeRepository BusinessEmployee { get; }

        IDesignationRepository Designation { get; }
        IQualificationRepository Qualification { get; }

        IAmbulatoryTypeRepository AmbulatoryType { get; }
        IEmployeeTypeRepository EmployeeType { get; }
        IHospitalTypeRepository HospitalType { get; }
        IMedicalInsuranceTypeRepository MedicalInsuranceType { get; }
        IMedicalSuppliesTypeRepository MedicalSuppliesType { get; }
        INursingTypeRepository NursingType { get; }
        IPharmaceuticalTypeRepository PharmaceuticalType { get; }
        ITestingLabTypeRepository TestingLabType { get; }

        IHealthcareBranchRepository HealthcareBranch { get; }
        IHealthcareDoctorRepository HealthcareDoctor { get; }

        INationalityRepository Nationality { get; }
        IDoctorLanguageRepository DoctorLanguage { get; }

        IStateRepository State { get; }
        IDistrictRepository District { get; }
        ICountRepository Count { get; }
        bool Save();



    }
}
