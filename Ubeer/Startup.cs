using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Azure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenJwt;
using Ubeer.METIER.Service;

namespace Ubeer.API
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

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ubeer.API", Version = "v1" });
			});

			services.AddSingleton(typeof(Address_Service), new Address_Service());
			services.AddSingleton(typeof(Beer_Service), new Beer_Service());
			services.AddSingleton(typeof(BeerQuantity_Service), new BeerQuantity_Service());
			services.AddSingleton(typeof(BeerStyle_Service), new BeerStyle_Service());
			services.AddSingleton(typeof(Brewery_Service), new Brewery_Service());
			services.AddSingleton(typeof(Command_Service), new Command_Service());
			services.AddSingleton(typeof(Stock_Service), new Stock_Service());
			services.AddSingleton(typeof(User_Service), new User_Service());

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
				options.TokenValidationParameters = new TokenValidationParameters{ValidateIssuer = false,
																				ValidateAudience = false,
																				ValidateIssuerSigningKey = true,
																				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7CB8D7280C17511D569392CAE97B3DAF"))
																				}
			);

			services.AddDistributedMemoryCache();
			services.AddSession(options =>
			{
				options.Cookie.HttpOnly = true;
				options.IdleTimeout = TimeSpan.FromSeconds(10);
			});

			IServiceCollection serviceCollection = services.AddTransient<IJwtAuthentication_Service, JwtAuthentication_Service>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ubeer.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

            app.UseCors(x => x
				 .AllowAnyMethod()
				 .AllowAnyHeader()
				 .AllowCredentials()
				 .WithOrigins("http://localhost:3000")
				 .SetIsOriginAllowed(origin => true));

            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}