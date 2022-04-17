// See https://aka.ms/new-console-template for more information
using Templates;

Console.WriteLine("Hello, World!");

var di = new DiskInfo("d:\\");

Console.WriteLine($"Размер диска {di.DiskName} = {di.MTotalSpace} Мбайт");

var report = new Report(di, "Template.docx", "Report");

report.Generate();

Console.WriteLine("Готово");
