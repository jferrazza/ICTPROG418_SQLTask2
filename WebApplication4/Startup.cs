using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static void RunQueryExternal(string q)
        {

            SqlConnection sqlc = new SqlConnection(Startup.constring);
            sqlc.Open();
            SqlCommand sql = new SqlCommand(q, sqlc);
            sql.ExecuteNonQuery();
            sqlc.Dispose();
        }

        public IConfiguration Configuration { get; }
        #region
        public static string constring = "Server=tcp:s102116925jf.database.windows.net,1433;Initial Catalog=DAD;Persist Security Info=False;User ID=jordan;Password=databases123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        #endregion
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //https://stackoverflow.com/questions/46930090/unable-to-resolve-service-for-type-while-attempting-to-activate/46930161
            services.AddDbContext<DADContext>(options => options.UseSqlServer(constring));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
