namespace Api.Models
{
    public class RoleLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var roles = context.User.Claims
                    .Where(c => c.Type == System.Security.Claims.ClaimTypes.Role)
                    .Select(c => c.Value);

                Console.WriteLine($"User Roles: {string.Join(", ", roles)}");
            }

            await _next(context);
        }
    }
}