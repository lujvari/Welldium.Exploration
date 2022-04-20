using MediatR;
using Welldium.Exploration.Domain;
using Welldium.Exploration.Domain.Interfaces;
using Welldium.Exploration.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(AddRobotRequestHandler));
builder.Services.AddMediatR(typeof(RemoveRobotRequestHandler));
builder.Services.AddMediatR(typeof(SimulateMovesRequestHandler));
builder.Services.AddSingleton<IRobotRepository, RoborRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
