using FactoryPattern.API.Abstracts;
using FactoryPattern.API.Factories;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

#region Factory lifetimes

builder.Services.AddSingleton<IInvoiceGeneratorFactory, InvoiceGeneratorFactory>();

#endregion

builder.Services.AddOpenApi();
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
