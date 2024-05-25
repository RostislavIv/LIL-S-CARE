namespace LilisCareApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.

            //builder.Services.AddAppDbContext(builder.Configuration);

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("DevelopmentPolicy", configurePolicy =>
                {
                    configurePolicy
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithOrigins("https://localhost:7038")
                     .AllowCredentials();
                });

            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("DevelopmentPolicy");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}
