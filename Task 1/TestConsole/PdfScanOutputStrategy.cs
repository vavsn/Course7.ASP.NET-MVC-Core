using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public class PdfScanOutputStrategy : IScanOutputStrategy
{
    public static readonly ILog log = LogManager.GetLogger(typeof(PdfScanOutputStrategy));
    public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
    {
        //do pdf output
        using (FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
        {
            scannerDevice.Scan().Seek(0, SeekOrigin.Begin);
            scannerDevice.Scan().CopyTo(fileStream);
        }
        log.Info($"Сформирован файл {outputFileName}. Загрузка процессора {scannerDevice.Proc()}%. Загрузка памяти {scannerDevice.Mem()}%");
    }
}
