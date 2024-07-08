The Adapter Pattern is a structural design pattern that allows incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces by converting the interface of a class into another interface that a client expects.

### Example of Adapter Pattern:

Suppose you have an existing `LegacyPrinter` class that has a method `Print(string text)` but you need to use it in a system that expects a different interface, `IPrinter`, which has methods `Initialize()` and `PrintDocument(string document)`.

Here’s how you can implement the Adapter Pattern:

```csharp
// Existing class with incompatible interface
public class LegacyPrinter
{
    public void Print(string text)
    {
        Console.WriteLine($"Legacy Printer: {text}");
    }
}

// Target interface expected by the client
public interface IPrinter
{
    void Initialize();
    void PrintDocument(string document);
}

// Adapter class that implements the target interface
public class LegacyPrinterAdapter : IPrinter
{
    private LegacyPrinter legacyPrinter;

    public LegacyPrinterAdapter(LegacyPrinter printer)
    {
        this.legacyPrinter = printer;
    }

    public void Initialize()
    {
        // No initialization needed for legacy printer
        Console.WriteLine("Legacy Printer Initialized");
    }

    public void PrintDocument(string document)
    {
        // Convert the method call to match the legacy printer's interface
        this.legacyPrinter.Print(document);
    }
}

// Client code that expects IPrinter interface
public class Client
{
    private IPrinter printer;

    public Client(IPrinter printer)
    {
        this.printer = printer;
    }

    public void PrintDocument(string document)
    {
        printer.Initialize();
        printer.PrintDocument(document);
    }
}

// Usage
public class Program
{
    public static void Main(string[] args)
    {
        LegacyPrinter legacyPrinter = new LegacyPrinter();
        IPrinter adapter = new LegacyPrinterAdapter(legacyPrinter);

        Client client = new Client(adapter);
        client.PrintDocument("Hello Adapter Pattern!");
    }
}
```

### Explanation:
- **LegacyPrinter**: Represents an existing class with an incompatible interface (`Print(string text)`).
- **IPrinter**: Defines the target interface that the client code expects (`Initialize()` and `PrintDocument(string document)`).
- **LegacyPrinterAdapter**: Acts as an adapter that implements the `IPrinter` interface and internally delegates the calls to `LegacyPrinter` methods.
- **Client**: Consumes the `IPrinter` interface without knowing the details of the legacy implementation.

In this example, `LegacyPrinterAdapter` adapts the `LegacyPrinter` class to the `IPrinter` interface, allowing the client (`Client` class) to interact with the legacy printer through the expected interface methods (`Initialize()` and `PrintDocument(string document)`). This pattern enables reusability of existing classes with different interfaces and promotes interoperability between otherwise incompatible systems.