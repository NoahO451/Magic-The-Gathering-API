using MagicTheGathering.API.Repositories;

namespace MagicTheGathering.API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICardRepository, CardRepository>();
            builder.Services.AddSingleton<IDeckRepository, MockDeckRepository>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();


            app.Run();
        }
    }
}
