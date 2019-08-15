using MarvelComicsLibrary.Application.AutoMapper;
using MarvelComicsLibrary.Business.Business;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Repository.Interface;
using MarvelComicsLibrary.Repository.Repository;
using MarvelComicsLibrary.Service.Interface;
using MarvelComicsLibrary.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MarvelComicsLibrary.Application.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureInjection(this IServiceCollection services)
        {
            var autoMapperConfig = AutoMapperConfig.Register();
            services.AddSingleton(autoMapperConfig.CreateMapper());

            DependencyInjectionServices(services);
            DependencyInjectionBusiness(services);
            DependencyInjectionRepository(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void DependencyInjectionServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void DependencyInjectionBusiness(IServiceCollection services)
        {
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void DependencyInjectionRepository(IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
