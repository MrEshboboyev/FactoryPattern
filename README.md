# Factory Pattern for Invoice Generation

This project demonstrates a .NET implementation of the Factory Pattern to generate invoices in multiple file formats (PDF, TXT, and CSV). It uses QuestPDF to create professional-grade PDF documents and follows the Repository Pattern to ensure clean and maintainable data access.

## Features

- **Factory Pattern**: Simplifies the creation of invoices in various file formats.
- **Invoice Generation**: Supports generating invoices as PDF, TXT, and CSV files.
- **QuestPDF Integration**: Produces high-quality and customizable PDF invoices.
- **Repository Pattern**: Provides a structured and maintainable data access layer.
- **Extensible Design**: Easily add support for new file formats or invoice types.

## Prerequisites

- [.NET 6 or higher](https://dotnet.microsoft.com/download)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/MrEshboboyev/FactoryPattern.git
   ```
2. Navigate to the project directory:
   ```bash
   cd FactoryPattern
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Usage

### Invoice Generation

The application uses the Factory Pattern to generate invoices in different formats. Below is an example of how to generate invoices in endpoint:

```csharp
var generator = invoiceGeneratorFactory.CreateInvoiceGenerator(format);
var invoiceData = generator.GenerateInvoice(id);
var contentType = generator.GetContentType();

var fileName = $"Invoice_{id}.{format.ToString().ToLower()}";
    
return Results.File(invoiceData, contentType, fileName);
```

### Adding New Formats

To support a new file format:
1. Create a new class implementing the `IInvoiceGenerator` interface.
2. Add the new file type to the `InvoiceFormat` enum.
3. Update the `InvoiceGeneratorFactory` to include the new type.

Example:
```csharp
public class ExcelInvoiceGenerator : IInvoiceGenerator
{
    public byte[] GenerateInvoice(Guid invoiceId)
    {
        // Logic to generate an Excel invoice
    }
}
```

## Supported File Formats

- **PDF**: Generated using [QuestPDF](https://www.questpdf.com/).  
- **CSV**: Comma-separated structured invoice data.  
- **TXT**: Simple text-based invoice output.

## Contributing

Contributions are welcome! Follow these steps:
1. Fork the repository.
2. Create a feature branch: `git checkout -b feature-name`.
3. Commit your changes: `git commit -m "Add feature"`.
4. Push to the branch: `git push origin feature-name`.
5. Open a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Acknowledgements

- [QuestPDF](https://www.questpdf.com/)  
- [Factory Design Pattern](https://refactoring.guru/design-patterns/factory-method)  
- [Repository Pattern](https://martinfowler.com/eaaCatalog/repository.html)  

---

Happy coding! 🚀
