using Hotels.Api.Converters;
using Hotels.Api.Filters;
using Hotels.Business.Mapper;
using Hotels.Business.UseCases;
using Hotels.Infrastructure.Context;
using Hotels.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Hotels.Api
{
    public class Startup(IConfiguration configuration)
    {
        protected readonly IConfiguration _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter("yyyy-MM-ddTHH:mm:ssZ"));
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerApplyOptionalRouteParameterOperationFilter>();
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotels.Api", Version = "v1" });
            });

            services.AddCors();
            services.AddHttpContextAccessor();

            AddDatabase(services);
            AddMappers(services);
            AddRepositories(services);
            AddUseCases(services);
            AddServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local") || env.IsEnvironment("QA"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotels Http Api v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDatabase(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("Hotels");
            services.AddDbContext<IHotelContext, HotelContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Hotels.Infrastructure")));
        }

        private void AddMappers(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
            }, GetType().Assembly);
            services.AddMapperServices();
        }

        private void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ISaveHotelUseCase, SaveHotelUseCase>();
            services.AddScoped<ISaveRoomUseCase, SaveRoomUseCase>();
            //services.AddScoped<ISaveReservationUseCase, SaveReservationUseCase>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
        }
    }
}
