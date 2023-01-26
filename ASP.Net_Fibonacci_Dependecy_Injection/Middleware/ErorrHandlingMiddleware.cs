namespace ASP.Net_Fibonacci_Dependecy_Injection.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
            context.Response.ContentType = "text/html; charset=utf-8";
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("<h1 style = 'color: red'>" +
                    "Invalid token!</h1>");
            }
            else if(context.Response.StatusCode == 405)
            {
                await context.Response.WriteAsync("<h1 style = 'color: red'>" +
                    "Incorrect index for fibonacci number!</h1>");
            }
            else if(context.Response.StatusCode == 406)
            {
                await context.Response.WriteAsync("<h1 style = 'color: orange'>Welcome! " +
                    "Please enter \"/fibonacci\" in the address to launch the app!</h1>");
            }
        }
    }
}
