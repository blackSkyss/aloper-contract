using ALOPER.API.Extentions;
using FluentValidation;
using System.Reflection;

namespace ALOPER.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(opts
                    => opts.SuppressModelStateInvalidFilter = true);
            //builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddConfigSwagger();

            builder.Services.AddDbFactory();
            builder.Services.AddUnitOfWork();
            builder.Services.AddServices();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddExceptionMiddleware();


            //add CORS
            builder.Services.AddCors(cors => cors.AddPolicy(
                                        name: "WebPolicy",
                                        policy =>
                                        {
                                            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                        }
                                    ));

            var app = builder.Build();
            app.AddApplicationConfig();
            app.Run();
        }
    }
}
