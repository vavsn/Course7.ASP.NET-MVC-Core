namespace TestConsole;
public interface IScannerDevice
{
    Stream Scan();
    double Proc();
    double Mem();
}

public class ScannerDevice : IScannerDevice
{
    private string inputFileName;

    public double Proc()
    { 
        Random rnd = new Random();

        return rnd.Next(0, 100);
    }
    public double Mem()
    { 
            Random rnd = new Random();

            return rnd.Next(0, 100);
    }

    public ScannerDevice(string inputFileName = "021.jpg")
    {
        this.inputFileName = inputFileName;
    }

    public Stream Scan()
    {
        if (string.IsNullOrWhiteSpace(inputFileName))
        {
            inputFileName = Guid.NewGuid().ToString();
        }

        Stream _device;
        _device = new FileStream(inputFileName, FileMode.Open, FileAccess.Read, FileShare.Read);

        return _device;
    }
}
