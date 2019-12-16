using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplication3GraphQL.GraphQL.Inputs;
using WebApplication3GraphQL.GraphQL.Mutations;
using WebApplication3GraphQL.GraphQL.Queries;
using WebApplication3GraphQL.GraphQL.Schemas;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Helpers;
using WebApplication3GraphQL.Mappings;
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

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

//            var appSettings = appSettingSection.Get<AppSettings>();
//            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
//            services.AddAuthentication(x =>
//                {
//                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                })
//                .AddJwtBearer(x =>
//                    {
//                        x.RequireHttpsMetadata = false;
//                        x.SaveToken = true;
//                        x.TokenValidationParameters = new TokenValidationParameters
//                        {
//                            ValidateIssuerSigningKey = true,
//                            IssuerSigningKey = new SymmetricSecurityKey(key),
//                            ValidateIssuer = false,
//                            ValidateAudience = false
//                        };
//                    }
//                );

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddSession();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ISensorsGroupsRepository, SensorGroupsRepository>();
            services.AddTransient<ISensorDatasRepository, SensorDatasRepository>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ISensorGroupsService, SensorGroupsService>();
            services.AddTransient<ISensorDatasService, SensorDatasService>();

            services.AddTransient<UsersSchema>();
            services.AddTransient<SensorGroupsSchema>();
            services.AddTransient<SensorDatasSchema>();

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
                Path = "/ui/playground",
                GraphQLEndPoint = "/graphql/user"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql"
            });
            app.UseMvc();
        }
    }
}