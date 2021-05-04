using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shopping.DataLayer.AutoMapperStructure;
using Microsoft.EntityFrameworkCore;
using Shopping.DataLayer.Models;

namespace Shopping.API
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration,IWebHostEnvironment webHostEnvironment)
        {
            _config = configuration;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc( options=>  options.EnableEndpointRouting = false );
            var mapperConfig = new MapperConfiguration(mc =>{
                mc.AddProfile(new Automap());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("ShoppingSitedb"))
                );
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMvc();
            app.UseAuthorization();
        }
    }
}
