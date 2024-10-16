using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using textanalyzer.Utility;
using TextAnalyzer.Utility;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<StringVerifier>();
builder.Services.AddSingleton<StringAppearances>();
builder.Services.AddSingleton<DecimalFormater>();
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Text analyzer by (C)Alexander Orlovsky\nMIT license");
app.MapControllers();

app.Run();
