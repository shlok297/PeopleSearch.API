﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using PeopleSearch.API.Data;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.API.Interface;
using PeopleSearch.API.Repository;
using PeopleSearch.API.Constants;

namespace PeopleSearch.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase());
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddMvc();
            services.AddCors();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(ErrorMessages.InternalServer);
                    });
                });
            }
            Mapper.Initialize(config =>
            {
                config.CreateMap<Dtos.UserDto, Models.Address>()
                    .ForMember(destination => destination.StreetAddress, opt => opt.MapFrom(source => source.StreetAddress))
                    .ForMember(destination => destination.City, opt => opt.MapFrom(source => source.City))
                    .ForMember(destination => destination.State, opt => opt.MapFrom(source => source.State))
                    .ForMember(destination => destination.Country, opt => opt.MapFrom(source => source.Country))
                    .ForMember(destination => destination.Zip, opt => opt.MapFrom(source => source.Zip));

                config.CreateMap<Dtos.UserDto, Models.User>()
                    .ForMember(destination => destination.FirstName, opt => opt.MapFrom(source => source.FirstName.ToLower()))
                    .ForMember(destination => destination.LastName, opt => opt.MapFrom(source => source.LastName.ToLower()));
            });
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();
        }
    }
}
