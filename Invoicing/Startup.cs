using AutoMapper;
using Data;
using Entity;
using Mapper.CategoryMapper;
using Mapper.DeliveryMapper;
using Mapper.DetailMapper;
using Mapper.InvoiceMapper;
using Mapper.ProductMapper;
using Mapper.StateInvoiceMapper;
using Mapper.StateMapper;
using Mapper.UserMapper;
using Mapper.UserTypeMapper;
using Mapper.WayToPayMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Interface;
using Repository.Repository;

namespace Invoicing
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvoicingContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var mapperConfiguration = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new CategoryMapper());
                mapper.AddProfile(new DeliveryMapper());
                mapper.AddProfile(new DetailMapper());
                mapper.AddProfile(new InvoiceMapper());
                mapper.AddProfile(new ProductMapper());
                mapper.AddProfile(new StateInvoiceMapper());
                mapper.AddProfile(new StateMapper());
                mapper.AddProfile(new UserMapper());
                mapper.AddProfile(new UserTypeMapper());
                mapper.AddProfile(new WayToPayMapper());
            }).CreateMapper();
            services.AddSingleton(mapperConfiguration);
            services.AddMvc();

            services.AddScoped<IBasicCRUD<CategoryDTO>, CategoryRepository>();
            services.AddScoped<ICreateCRUD<CategoryDTO>, CategoryRepository>();
            services.AddScoped<IDeleteCRUD<CategoryDTO>, CategoryRepository>();
            services.AddScoped<IUpdateCRUD<CategoryDTO>, CategoryRepository>();
            services.AddScoped<IBasicCRUD<DeliveryDTO>, DeliveryRepository>();
            services.AddScoped<ICreateCRUD<DeliveryDTO>, DeliveryRepository>();
            services.AddScoped<IDeleteCRUD<DeliveryDTO>, DeliveryRepository>();
            services.AddScoped<IUpdateCRUD<DeliveryDTO>, DeliveryRepository>();
            services.AddScoped<IBasicCRUD<DetailDTO>, DetailRepository>();
            services.AddScoped<ICreateCRUD<DetailDTO>, DetailRepository>();
            services.AddScoped<IBasicCRUD<InvoiceDTO>, InvoiceRepository>();
            services.AddScoped<ICreateCRUD<InvoiceDTO>, InvoiceRepository>();
            services.AddScoped<IDeleteCRUD<InvoiceDTO>, InvoiceRepository>();
            services.AddScoped<IBasicCRUD<ProductDTO>, ProductRepository>();
            services.AddScoped<ICreateCRUD<ProductDTO>, ProductRepository>();
            services.AddScoped<IDeleteCRUD<ProductDTO>, ProductRepository>();
            services.AddScoped<IUpdateCRUD<ProductDTO>, ProductRepository>();
            services.AddScoped<IBasicCRUD<StateInvoiceDTO>, StateInvoiceRepository>();
            services.AddScoped<ICreateCRUD<StateInvoiceDTO>, StateInvoiceRepository>();
            services.AddScoped<IDeleteCRUD<StateInvoiceDTO>, StateInvoiceRepository>();
            services.AddScoped<IUpdateCRUD<StateInvoiceDTO>, StateInvoiceRepository>();
            services.AddScoped<IBasicCRUD<StateDTO>, StateRepository>();
            services.AddScoped<ICreateCRUD<StateDTO>, StateRepository>();
            services.AddScoped<IDeleteCRUD<StateDTO>, StateRepository>();
            services.AddScoped<IUpdateCRUD<StateDTO>, StateRepository>();
            services.AddScoped<IBasicCRUD<UserDTO>, UserRepository>();
            services.AddScoped<ICreateCRUD<UserDTO>, UserRepository>();
            services.AddScoped<IDeleteCRUD<UserDTO>, UserRepository>();
            services.AddScoped<IUpdateCRUD<UserDTO>, UserRepository>();
            services.AddScoped<IBasicCRUD<UserTypeDTO>, UserTypeRepository>();
            services.AddScoped<ICreateCRUD<UserTypeDTO>, UserTypeRepository>();
            services.AddScoped<IBasicCRUD<WayToPayDTO>, WayToPayRepository>();
            services.AddScoped<ICreateCRUD<WayToPayDTO>, WayToPayRepository>();
            services.AddScoped<IDeleteCRUD<WayToPayDTO>, WayToPayRepository>();
            services.AddScoped<IUpdateCRUD<WayToPayDTO>, WayToPayRepository>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoicing v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
