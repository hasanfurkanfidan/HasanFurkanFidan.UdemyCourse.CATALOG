using HasanFurkanFidan.UdemyCourse.CATALOG.API.Data.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Data.Concrete;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Concrete;
using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.IOC
{
    public static class AddDependencies
    {
        public static void DependencyResolver(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<,>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICourseService, CourseManager>();
        }
    }
}
