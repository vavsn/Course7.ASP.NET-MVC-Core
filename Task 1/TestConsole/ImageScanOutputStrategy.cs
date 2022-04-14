using log4net;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestConsole;

public class ImageScanOutputStrategy : IScanOutputStrategy
{

    public static readonly ILog log = LogManager.GetLogger(typeof(ImageScanOutputStrategy));
    public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
    {
        Image img = Image.FromStream(scannerDevice.Scan());

        //do image outptut
        img.Save(outputFileName, ImageFormat.Jpeg);
        log.Info($"Сформирован файл {outputFileName}. Загрузка процессора {scannerDevice.Proc()}%. Загрузка памяти {scannerDevice.Mem()}%");
    }
}
