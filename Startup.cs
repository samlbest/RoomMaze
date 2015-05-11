using Microsoft.AspNet.Builder;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using RoomMaze.Repositories;
using RoomMaze.Services;

namespace RoomMaze
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }  

        public Startup()
        {
            this.Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }
        
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<Settings>(Configuration);
            services.AddSingleton<IRoomRepository, RoomRepository>();            
            services.AddScoped<IRoomService, RoomService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseWelcomePage();
        }
    }
    
}
