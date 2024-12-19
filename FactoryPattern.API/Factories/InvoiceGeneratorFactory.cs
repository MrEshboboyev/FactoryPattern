using FactoryPattern.API.Abstracts;
using FactoryPattern.API.Enums;
using FactoryPattern.API.Generators;

namespace FactoryPattern.API.Factories;

public class InvoiceGeneratorFactory : IInvoiceGeneratorFactory
{
    public IInvoiceGenerator CreateInvoiceGenerator(InvoiceFormat invoiceFormat)
    {
        return invoiceFormat switch
        {
            InvoiceFormat.Pdf => new PdfInvoiceGenerator(),
            InvoiceFormat.Txt => new TxtInvoiceGenerator(),
            InvoiceFormat.Csv => new CsvInvoiceGenerator(),
            _ => throw new ArgumentException("Invalid/Unsupported invoice format", nameof(invoiceFormat))
        };
    }
}