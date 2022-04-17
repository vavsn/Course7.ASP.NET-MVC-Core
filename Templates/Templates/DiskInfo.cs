using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates;

public class DiskInfo
{
    private static DriveInfo _disk;
    private static string _diskName;
    public string DiskName { get { return _diskName; } }

    public DiskInfo(string diskName="c:\\")
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            if(drive.Name.Equals(diskName, StringComparison.OrdinalIgnoreCase)) 
            {
                _diskName = diskName;
                _disk = drive;
            }
        }
    }

    public Int64 TotalSpace 
    { 
        get
        {
            if (_disk != null)
                return _disk.TotalSize;
            return 0;
        } 
    }
    public Int64 KTotalSpace
    {
        get
        {
            if (_disk != null)
                return _disk.TotalSize / 1024;
            return 0;
        }
    }
    public Int64 MTotalSpace
    {
        get
        {
            if (_disk != null)
                return _disk.TotalSize / 1024 / 1024;
            return 0;
        }
    }
    public Int64 FreeSpace
    {
        get
        {
            if (_disk != null)
                return _disk.AvailableFreeSpace;
            return 0;
        }
    }
    public int TotalNumberFolders
    {
        get
        {
            if (_disk != null)
            {
                return Directory.GetDirectories(_diskName).Length;
            }
            return 0;
        }
    }
}
