using FactoryPattern.API.Abstracts;
using FactoryPattern.API.Enums;
using FactoryPattern.API.Factories;
using FactoryPattern.API.Generators;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

#region Factory lifetimes

builder.Services.AddSingleton<IInvoiceGeneratorFactory, InvoiceGeneratorFactory>();

#endregion

#region Generators lifetimes

builder.Services.AddTransient<PdfInvoiceGenerator>();
builder.Services.AddTransient<TxtInvoiceGenerator>();
builder.Services.AddTransient<CsvInvoiceGenerator>();

#endregion

builder.Services.AddOpenApi();
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

#region Endpoints

app.MapGet("/api/invoice/{id:guid}/{format}", (Guid id,
        InvoiceFormat format,
        IInvoiceGeneratorFactory invoiceGeneratorFactory) =>
{
    var generator = invoiceGeneratorFactory.CreateInvoiceGenerator(format);
    var invoiceData = generator.GenerateInvoice(id);
    var contentType = generator.GetContentType();

    var fileName = $"Invoice_{id}.{format.ToString().ToLower()}";
    
    return Results.File(invoiceData, contentType, fileName);
})
    .WithName("GenerateInvoice")
    .WithOpenApi();

#endregion

app.UseHttpsRedirection();

app.Run();
