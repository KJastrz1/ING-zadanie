using Backend.Exceptions;
using Backend.Providers;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRateProvider, NbpCurrencyRateProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", builder =>
    {
        builder.WithOrigins("http://localhost:5062") 
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevCors");
}

app.UseMiddleware<ExceptionMiddleware>();


app.UseRouting();
app.MapControllers();
app.Run();

