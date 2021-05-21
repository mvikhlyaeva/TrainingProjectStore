using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TrainingProject.Core.Middlwares;
using TrainingProject.tables;


namespace TrainingProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789",
                    builder => builder.MigrationsAssembly(typeof(ApplicationContext).Assembly.GetName().Name))); //Πετλεκρθÿ


            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Auto Mapper Configurations
            /* var mapperConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new MappingProfile());
             });

             IMapper mapper = mapperConfig.CreateMapper();
             services.AddSingleton(mapper);*/

            services.AddMvc();
            services.AddMediatR(typeof(Startup));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ExceptionCatchMiddleware>();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            

        }
    }
}