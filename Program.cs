using ApiAppCot.Contexto;
using ApiAppCot.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(options => options.UseMySql(
    @"Server = localhost; Database = app_cot; Uid = root; Pwd = root", ServerVersion.Parse("8.0.29")
    ));
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Ativos>().OwnsOne(x => x.IdAtivos);
}

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
    var DelAtivo = await contexto.Ativos.FirstOrDefaultAsync(p => p.IdAtivos == id);
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

app.MapGet("ListAtivo/{id}", async (int id,Contexto contexto) =>
{
    return await contexto.Ativos.FirstOrDefaultAsync(p => p.IdAtivos == id);
});


app.MapGet("/", () => "Hello World!");
app.UseSwaggerUI();

app.Run();
