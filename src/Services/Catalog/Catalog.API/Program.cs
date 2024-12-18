using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
