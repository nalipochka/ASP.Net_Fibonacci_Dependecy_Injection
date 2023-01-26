using ASP.Net_Fibonacci_Dependecy_Injection.Services;

namespace ASP.Net_Fibonacci_Dependecy_Injection.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate next;

        public RoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, FibonacciService fibonacci)
        {
            string? path = context.Request.Path.Value?.ToLower();
            string value = context.Request.Query["index"];
            string token = context.Request.Query["token"];
            if (path == "/fibonacci")
            {
                if (token == "mazurok")
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("<h2 style='color: green;'>" +
                        "Web application for counting fibonacci numbers</h2>");
                    if (value != null)
                    {
                        int index = int.Parse(value);
                        if (index >= 0 && index <= 40)
                        {
                            await context.Response.WriteAsync($"<h1 style='color: pink'>F({index}) = {fibonacci.Fibonacci(index)}</h1>");
                        }
                        else
                        {
                            context.Response.StatusCode = 405;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 405;
                    }
                }
                else
                {
                    context.Response.StatusCode = 403;
                }
            }
            else
            {
                context.Response.StatusCode = 406;
            }
        }
    }
}
