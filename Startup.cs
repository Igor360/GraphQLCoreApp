using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication3GraphQL.GraphQL.Inputs;
using WebApplication3GraphQL.GraphQL.Mutations;
using WebApplication3GraphQL.GraphQL.Queries;
using WebApplication3GraphQL.GraphQL.Schemas;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Repositories;
using WebApplication3GraphQL.Services;
using AppContext = WebApplication3GraphQL.Contexts.AppContext;

namespace WebApplication3GraphQL
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ISensorsGroupsRepository, SensorGroupsRepository>();
            services.AddScoped<ISensorDatasRepository, SensorDatasRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISensorGroupsService, SensorGroupsService>();
            services.AddScoped<ISensorDatasService, SensorDatasService>();
            
            services.AddScoped<UsersSchema>();
            services.AddScoped<SensorGroupsSchema>();
            services.AddScoped<SensorDatasSchema>();
            
//            services.AddScoped<UsersInputType>();
//            services.AddScoped<UsersMutation>();
//            services.AddScoped<UsersType>();
//            services.AddScoped<UsersQuery>();
            services.AddGraphQL(opt =>
            {
                opt.EnableMetrics = true;
                opt.ExposeExceptions = true;
            }).AddDataLoader();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseGraphQL<UsersSchema>("/graphql/user");
            app.UseGraphQL<SensorGroupsSchema>("/graphql/groups");
            app.UseGraphQL<SensorDatasSchema>("/graphql/data");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql/user"
            });
            app.UseMvc();
        }
    }
}