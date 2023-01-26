using ASP.Net_Fibonacci_Dependecy_Injection.Middleware;
using ASP.Net_Fibonacci_Dependecy_Injection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<FibonacciService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RoutingMiddleware>();

app.Run();
