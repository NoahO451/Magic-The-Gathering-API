using MagicTheGathering.API.Repositories;

namespace MagicTheGathering.API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //lots of magic... 

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICardRepository, MockCardRepository>();
            builder.Services.AddSingleton<IDeckRepository, MockDeckRepository>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            //app.MapGet("/", () => "Hello World!"); 

            app.Run();
        }
    }
}
