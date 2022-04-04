
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace TestConsole;

public static class ExcelWorksheet
{


    public static void Run()
    {
        var _excel = new ExcelBuilder();
        _excel._NameWorkbook = "НоваяКнига";
        _excel._NameWorksheet = "Лист 1";
        _excel
            .NewExcelSheets(1, 2, "Test")
            .NewExcelSheets(1, 3, "Test 2")
            .NewExcelSheets(2, 1, "1")
            .NewExcelSheets(2, 2, "2")
            .NewExcelSheets(2, 3, "=A2+B2")
            ;

        var app = _excel.CreateExcel();
    }



}

public class ExcelBuilder
{
    private readonly List<(int Row, int Col, string Value)> excels = new ();
    public string _NameWorkbook { get; set; } = "MyBook.xlsx";

    public string _NameWorksheet { get; set; } = "MySheet 1";

    public int Row { get; set; } = 1;
    public int Col { get; set; } = 1;

    public string Value { get; set; }

    public ExcelBuilder NewExcelSheets(int Row, int Col, string Value)
    {
        excels.Add((Row, Col, Value));
        return this;
    }

    public Excel.Application CreateExcel()
    {
        Excel.Application application = null;
        Excel.Workbooks workbooks = null;
        Excel.Workbook workbook = null;
        Excel.Sheets worksheets = null;
        Excel.Worksheet worksheet = null;
        Excel.Range cell = null;
        application = new Excel.Application
        {
            Visible = true
        };
        workbooks = application.Workbooks;
        workbook = workbooks.Add();
        worksheets = workbook.Worksheets; 
        worksheet = worksheets.Item[1];
        worksheet.Name = _NameWorksheet; 

        foreach(var (Row, Col, Value) in excels)
        {
            worksheet.Cells[Row, Col].value = Value;
        }

        application.DisplayAlerts = false;

        workbook.Close(true, _NameWorkbook);

        application.Quit();

        return application;
    }

}


