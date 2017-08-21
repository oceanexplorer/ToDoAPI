﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;
using System;
using TodoApi.Domain;
using Microsoft.Extensions.Configuration;

namespace TodoApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;        

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  
            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Testing123";
            var connectionString = $"Data Source={hostname};Initial Catalog=TodoManager;User ID=sa;Password={password};";          

            services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(connectionString));
            services.AddMvc();
            services.AddTransient<TodoManager, TodoManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}