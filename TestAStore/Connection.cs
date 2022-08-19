using System;
using System.IO;

namespace TestAStore
{

    class Connection
    {
        static string _connectionString = "";


        public static string ConnectionString
        {
            get
            {
                stringLoad(_fileName);
                return _connectionString;
            }
        }


        private static string _fileName = AppDomain.CurrentDomain.BaseDirectory + "app.config";



        private static void stringLoad(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
                {
                    _connectionString = reader.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при чтении файла конфигурации подключения к базе \n создайте подключение! " + e.Message);
            }

        }





        public static void SetConnection(string[] args)
        {

            if (args.Length == 5)
            {
                _connectionString = @"Data Source=" + args[1] + ";Initial Catalog=" + args[2] + ";Persist Security Info=True;User ID=" + args[3] + ";Password=" + args[4];

                stringSave(_fileName, _connectionString);
                Console.WriteLine("Строка подключения создана.");
            }


        }


        private static void stringSave(string fileName, string savedString)
        {
            if (savedString != "")
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate)))
                {
                    writer.WriteLine(savedString);
                }
            }

        }






    }
}
