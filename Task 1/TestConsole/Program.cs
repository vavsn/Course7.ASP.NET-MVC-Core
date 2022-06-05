using log4net;
using log4net.Config;
using TestConsole;

Console.WriteLine("Начинаем работать");

XmlConfigurator.Configure(new System.IO.FileInfo("logger.conf"));

var fileName = "021.jpg";
var scan = new ScannerDevice(fileName);
var sCont = new ScannerContext(scan);
var imageStrat = new ImageScanOutputStrategy();
sCont.SetupOutputScanStrategy(imageStrat);
sCont.Execute("_"+fileName);

fileName = "021.pdf";
scan = new ScannerDevice(fileName);
sCont = new ScannerContext(scan);
var pdfStrat = new PdfScanOutputStrategy();
sCont.SetupOutputScanStrategy(pdfStrat);
sCont.Execute("_" + fileName);

Console.WriteLine("Закончили работать");
