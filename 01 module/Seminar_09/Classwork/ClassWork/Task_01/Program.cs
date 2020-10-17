using System;
using System.IO;
using System.Text;

namespace Task_01
{
    class Program
    {
        private static void DirectoryOverview(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            string[] Files = Directory.GetFiles(path);
            foreach (var item in Files)
            {
                Console.WriteLine(Directory.GetCreationTime(path + Path.VolumeSeparatorChar + item));
                Console.WriteLine(Directory.GetLastAccessTime(path + Path.VolumeSeparatorChar + item));
                Console.WriteLine(Directory.GetLastWriteTime(path + Path.VolumeSeparatorChar + item));


            }
        }

        private static void Main(string[] args)
        {
            try
            {

                DirectoryOverview(@"..\..\..\");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption" + ex.Message);

            }

            Console.WriteLine("Нажмите любую клавишу, чтобы выйти");

            Console.ReadLine();
            }
    }
}
