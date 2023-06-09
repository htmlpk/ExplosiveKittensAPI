using ExplosiveKittens.Business;
using ExplosiveKittens.Business.HostedServices;
using ExplosiveKittens.Business.Interfaces;
using ExplosiveKittensAPI.Hub;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM;
using Redis.OM.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

Startup.ConfigureRepositories(builder.Services);
Startup.ConfigureServices(builder.Services);
builder.Services.AddSignalR().AddNewtonsoftJsonProtocol();
builder.Services.AddHostedService<IndexCreationService>();
builder.Services.AddSingleton(new RedisConnectionProvider(builder.Configuration["REDIS_CONNECTION_STRING"]));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ExplosiveKittensHub>("/explosive-kittens-hub");
    endpoints.MapSwagger();
});

//app.UseSwaggerUI();

//app.MapControllers();

app.Run();
