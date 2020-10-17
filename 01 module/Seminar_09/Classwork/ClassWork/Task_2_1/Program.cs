using System;
using System.IO;

namespace Task_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine($"Drive {d.Name}");
            }
        }
    }
}
