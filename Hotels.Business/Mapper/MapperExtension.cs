using Hotels.Business.Mapper.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hotels.Business.Mapper
{
    public static class MapperExtension
    {
        public static void AddMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
            }, typeof(MapperExtension).Assembly);

            services.AddScoped<IHotelMapperService, HotelMapperService>();
        }
    }
}
