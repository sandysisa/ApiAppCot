using ApiAppCot.Contexto;
using ApiAppCot.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(options => options.UseMySql(
    "server = localhost; initial catalog = app_cot; uid = root; pwd = root", ServerVersion.Parse("8.0.29-mysql")));


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AddAtivo", async (Ativos ativo, Contexto contexto) =>
{
    contexto.Ativos.Add(ativo);
    await contexto.SaveChangesAsync();
});

app.MapPost("DelAtivo/{id}", async (int id, Contexto contexto) =>
{
    var DelAtivo = await contexto.Ativos.FirstOrDefaultAsync(p => p.Id == id);
    if (DelAtivo != null) 
    {
        contexto.Ativos.Remove(DelAtivo);
        await contexto.SaveChangesAsync();
    }
    else return;
});

app.MapGet("ListAtivos", async ( Contexto contexto) =>
{
    return await contexto.Ativos.ToListAsync();
});

app.MapGet("ListAtivos/{id}", async (int id,Contexto contexto) =>
{
    return await contexto.Ativos.FirstOrDefaultAsync(p => p.Id == id);
});


app.MapGet("/", () => "Home!");
app.UseSwaggerUI();

app.Run();
