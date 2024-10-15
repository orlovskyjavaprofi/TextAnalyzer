var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Text analyzer by (C)Alexander Orlovsky\nMIT license");

app.Run();
