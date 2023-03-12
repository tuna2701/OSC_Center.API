using Library.BusinessLogicLayer;
using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace OSC_Center.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddDbContext<osc_centerContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("MyDB"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IStudentBusiness, StudentBusiness>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<IRecordBusiness, RecordBusiness>();
            services.AddTransient<IRecordRepository, RecordRepository>();

            services.AddTransient<IConsultancyBusiness, ConsultancyBusiness>();
            services.AddTransient<IConsultancyRepository, ConsultancyRepository>();

            services.AddTransient<IPlanBusiness, PlanBusiness>();
            services.AddTransient<IPlanRepository, PlanRepository>();

            services.AddTransient<IContractBusiness, ContractBusiness>();
            services.AddTransient<IContractRepository, ContractRepository>();

            services.AddTransient<IIncomeBusiness, IncomeBusiness>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();

            services.AddTransient<ICourseBusiness, CourseBusiness>();
            services.AddTransient<ICourseRepository, CourseRepository>();

            services.AddTransient<IPostBusiness, PostBusiness>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddTransient<ICommissionBusiness, CommissionBusiness>();
            services.AddTransient<ICommissionRepository, CommissionRepository>();

            services.AddMemoryCache();

            var MimeTypes = new[]
                                {
                                    // General
                                    "text/plain",
                                    // Static files
                                    "text/css",
                                    "application/javascript",
                                    // MVC
                                    "text/html",
                                    "application/xml",
                                    "text/xml",
                                    "application/json",
                                    "text/json",
                                    "image/svg+xml",
                                    "application/atom+xml"
                                };
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(MimeTypes); ;
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = Int32.MaxValue;
                x.MultipartBodyLengthLimit = Int32.MaxValue;
                x.MultipartHeadersLengthLimit = Int32.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                
            //}

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Booking API v1"));
            app.UseCors("AllowAll");

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
