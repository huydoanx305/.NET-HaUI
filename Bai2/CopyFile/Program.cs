using System;
using System.IO;
using System.Text;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string sourcePath = "D:/C#/Bai2/TapTin/filesource.txt";
            string targetPath = "D:/C#/Bai2/TapTin/filetarget.txt";

            // Cách 1: File
            //File.Copy(sourcePath, targetPath, true);

            // Cách 2: StreamReader và StreamWriter
            StreamReader reader = new StreamReader(sourcePath);
            StreamWriter writer = new StreamWriter(targetPath);
            try
            {
                writer.Write(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }

            writer.Close();
            reader.Close();
        }
    }
}
