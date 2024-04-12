using DemoWebApp.Application.Common.Constant;
using DemoWebApp.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using System.Text;

namespace DemoWebApp.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAppApi(this IServiceCollection services, IConfiguration configuration)
        {
            #region Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            #endregion

            #region JwtWebToken
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                JwtOptions jwtOptions = new JwtOptions();
                configuration.GetSection(Constants.JWT_OPTIONS).Bind(jwtOptions);

                var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secretkey));

                jwt.TokenValidationParameters = new TokenValidationParameters();
                jwt.TokenValidationParameters.ValidIssuer = jwtOptions.Issuer;
                jwt.TokenValidationParameters.ValidAudience = jwtOptions.Audience;
                jwt.TokenValidationParameters.ValidateIssuer = true;
                jwt.TokenValidationParameters.ValidateAudience = true;
                jwt.TokenValidationParameters.IssuerSigningKey = issuerSigningKey;
            });
            #endregion


            services.AddControllers(options => options.ModelValidatorProviders.Clear())
                    //handle JSON Patch requests 
                    .AddNewtonsoftJson(o => { o.SerializerSettings.Converters.Add(new StringEnumConverter()); });

            return services;
        }
    }
}
