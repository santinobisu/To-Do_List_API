// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

}



// Configure the HTTP request pipeline.
var app = builder.Build();
{
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
