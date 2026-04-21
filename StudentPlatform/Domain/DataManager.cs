using StudentPlatform.Domain.Repositories.Abstract;

namespace StudentPlatform.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories {  get; set; }
        public IServicesRepository Services { get; set; }
        public DataManager(IServiceCategoriesRepository serviceCategoriesRepository, IServicesRepository servicesRepository) 
        {
            ServiceCategories = serviceCategoriesRepository;
            Services = servicesRepository;
        }
    }
}
