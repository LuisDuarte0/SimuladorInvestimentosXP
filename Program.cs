using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Simulador de Investimentos XP",
        Version = "v1",
        Description = "API para simulação de investimentos na XP. Feito por: Luis Duarte.",
    });
});

var app = builder.Build();

// Permite servir arquivos estáticos (imagens, CSS, JS)
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger/custom.css"); // Aplica o CSS customizado
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simulador de Investimentos XP v1");
        c.DocumentTitle = "API XP Investimentos";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
