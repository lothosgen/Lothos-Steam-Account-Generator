using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Hardwareinfo;

namespace SteamAccCreator.File
{
    class UUID
    {
        public static string LocalIP = HardwareInfo.GetLocalIPAddress();
        public static string CPUID = HardwareInfo.GetProcessorId();
        public static string MACAddressID = HardwareInfo.GetMACAddress();
        public static string BoardProductID = HardwareInfo.GetBoardProductId();
        public static string PhysicalMemory = HardwareInfo.GetPhysicalMemory();
        public static string BoardMaker = HardwareInfo.GetBoardMaker();
        public static string HDDID = HardwareInfo.GetHDDSerialNo();
        public static string CPUGHZ = HardwareInfo.GetCpuSpeedInGHz().ToString();
        public static string[] OSVersion;

        public static string fullversion = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>() select x.GetPropertyValue("Caption")).FirstOrDefault().ToString();

        public static string ID = "";

        public static string get()
        {
            OSVersion = fullversion.Split(' ');
            ID = CPUID.Replace(" ", "") + "-" + MACAddressID.Replace(" ", "") + "-" + BoardProductID.Replace(" ", "") + "-" + LocalIP.Replace(" ", "").Replace(".", "") + "-" + HDDID.Replace(" ", "") + "-" + CPUGHZ + "-" + OSVersion[2];
            return ID;
        }
    }
}
