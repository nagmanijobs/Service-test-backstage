var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    service = "Service-test-backstage",
    message = "Hello World from .NET 8 running on ECS"
}));

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
