using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace Templates;

public class Report
{
    private DiskInfo _diskInfo;
    private readonly string _templatename;
    private readonly string _reportname;
    private string _output;

    public Report(DiskInfo diskInfo, string templatename, string reportname)
    {
        _diskInfo = diskInfo;
        _templatename = Path.Combine(Directory.GetCurrentDirectory(), templatename);
        _reportname = reportname;
    }

    public void Generate()
    {
        var ext = new FileInfo(_templatename).Extension;
        _output = Path.Combine(Directory.GetCurrentDirectory(),_reportname+ext);
        if (File.Exists(_output))
        {
            try
            {
                File.Delete(_output);
            }
            catch 
            {
                throw new Exception($"Файл {_output} открыт");
            }
        }
        File.Copy(_templatename, _output);
        var valuesToFill = new Content(
            new FieldContent("DiskName", _diskInfo.DiskName),
            new FieldContent("TotalSpace", _diskInfo.TotalSpace.ToString()),
            new FieldContent("KTotalSpace", _diskInfo.KTotalSpace.ToString()),
            new FieldContent("MTotalSpace", _diskInfo.MTotalSpace.ToString()),
            new FieldContent("FreeSpace", _diskInfo.FreeSpace.ToString()),
            new FieldContent("NumberFolders", _diskInfo.TotalNumberFolders.ToString())
            );

        using (var outputDocument =
            new TemplateProcessor(_output)
            .SetRemoveContentControls(true))
        {
            outputDocument.FillContent(valuesToFill);
            outputDocument.SaveChanges();
        }
    }

}

