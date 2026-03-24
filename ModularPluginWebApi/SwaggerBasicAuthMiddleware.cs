using System.Text;

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public SwaggerBasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger") ||
            context.Request.Path == "/" ||
            context.Request.Path == "/index.html")
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var parts = usernamePassword.Split(':');
                if (parts.Length == 2)
                {
                    var username = parts[0];
                    var password = parts[1];

                    if (username == "admin" && password == "1234")
                    {
                        await _next(context);
                        return;
                    }
                }
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authentication required.");
            return;
        }

        await _next(context);
    }
}