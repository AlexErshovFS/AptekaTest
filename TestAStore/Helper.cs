using System;
using System.IO;
using System.Text;

namespace TestAStore
{


    class Helper
    {

        public static void Help()
        {
            try
            {
                using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "HelpFile.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ошибка открытия файла с описанием комманд:");
                Console.WriteLine(e.Message);
            }
        }



    }
}
