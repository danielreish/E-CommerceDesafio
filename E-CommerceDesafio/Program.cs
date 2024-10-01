using E_CommerceDesafio.Application.Services;
using E_CommerceDesafio.Infrastructure.Notifications;
using E_CommerceDesafio.Infrastructure.Payments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<PedidoService>();

builder.Services.AddTransient<IPagamento, PagamentoPix>();
builder.Services.AddTransient<IPagamento, PagamentoCartao>();

builder.Services.AddScoped<INotificacaoService, EmailNotificacaoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
