var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Самостоятельное задание: логирование в volume
Directory.CreateDirectory("/app/logs");
app.Use(async (ctx, next) =>
{
    var logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {ctx.Request.Method} {ctx.Request.Path}\n";
    await File.AppendAllTextAsync("/app/logs/access.log", logLine);
    await next();
});

// Самостоятельное задание: возвращаем текущее время
app.MapGet("/", () => $"Hello from Docker + C#! Server time: {DateTime.Now:HH:mm:ss}");

app.Run();
