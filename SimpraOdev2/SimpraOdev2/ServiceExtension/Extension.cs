using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace SimpraOdev2.ServiceExtension
{
    public static class Extension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Veri Tabanı Bağlantısı
            services.AddDbContext<Context>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
            #endregion
            #region AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            #endregion
            services.AddSingleton(config.CreateMapper());           
            #region Category
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion
            #region Product
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductService>();
            #endregion
        }
    }
}

