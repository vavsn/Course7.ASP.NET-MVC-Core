using Autofac;
using Autofac.Features.Metadata;
using log4net;
using log4net.Config;
using TestConsole;


class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<IScannerDevice>().As<ScannerDevice>().WithMetadata
            ("Name", "Устройство сканирования");
        builder.RegisterType<ImageScanOutputStrategy>().As<IScanOutputStrategy>()
            .WithMetadata("Name", "Сканирование в формате JPEG")
            .WithMetadata("inputFileName", "021.jpg"); 
        builder.RegisterType<PdfScanOutputStrategy>().As<IScanOutputStrategy>()
            .WithMetadata("Name", "Сканирование в формате PDF")
            .WithMetadata("inputFileName", "021.pdf"); 
        builder.RegisterAdapter<Meta<IScanOutputStrategy>, Operation>(
            cmd => new Operation(cmd.Value,
                (string)cmd.Metadata["Name"],
                (string)cmd.Metadata["inputFileName"]));
        IContainer container = builder.Build();
        IReadOnlyList<Operation> operations =
        container.Resolve<IEnumerable<Operation>>().ToList();
        foreach (Operation operation in operations)
        {
            Console.WriteLine($"Operation name is {operation.Name}");
            operation.Execute();
        }
    }
}

public sealed class Operation
{
    private readonly IScanOutputStrategy _scanoutputstrategy;
    private readonly string _name;
    private readonly string _inputFileName;
    public Operation(IScanOutputStrategy scanoutputstrategy, string name, string inputFileName)
    {
        _scanoutputstrategy = scanoutputstrategy;
        _name = name;
        _inputFileName = inputFileName;
    }
    public string Name => _name;
    public void Execute()
    {
        var scan = new ScannerDevice(_inputFileName);
        var sCont = new ScannerContext(scan);
        var ScanStrat = new ImageScanOutputStrategy();
        sCont.SetupOutputScanStrategy(ScanStrat);
        sCont.Execute("_" + _inputFileName);
    }
}


