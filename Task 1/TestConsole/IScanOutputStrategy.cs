namespace TestConsole;

public interface IScanOutputStrategy
{
    void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
}

