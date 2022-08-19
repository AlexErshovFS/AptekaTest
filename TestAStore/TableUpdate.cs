using System;
using System.Data.SqlClient;
using System.Text;

namespace TestAStore
{
    class TableUpdate
    {



        static StringBuilder _strBuilder = new StringBuilder();



        public static void InsTMC(string[] args)
        {
            if (args.Length == 2 && args[1] != "")
            {

                _strBuilder.Append("INSERT INTO TMC (Name_TMC) VALUES ");
                _strBuilder.Append($"('{args[1]}')");

                Insert(_strBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Неверно заданы аргументы");
            }

        }


       public static void InsStore(string[] args)
        {
            if (args.Length == 3)
            {

                _strBuilder.Append("INSERT INTO Store (ID_Apteka, Name) VALUES ");
                _strBuilder.Append($"({args[1]} , '{args[2]}')");

                Insert(_strBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Неверно заданы аргументы");
            }

        }


        public static void InsBatch(string[] args)
        {
            if (args.Length == 4)
            {

                _strBuilder.Append("INSERT INTO Batch (ID_TMC, ID_Store, Quantity) VALUES ");
                _strBuilder.Append($"({args[1]} , {args[2]}, {args[3]})");

                Insert(_strBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Неверно заданы аргументы");
            }

        }

        public static void InsApteka(string[] args)
        {
            if (args.Length == 4)
            {

                _strBuilder.Append("INSERT INTO Apteka (Name, Adress, Phone) VALUES ");
                _strBuilder.Append($"('{args[1]}' ,'{args[2]}', '{args[3]}')");

                Insert(_strBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Неверно заданы аргументы");
            }

        }

         


        static void Insert(string _sqlQuery)
        {
           
      
                      
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            try
            {

                conn.Open();

                using (SqlCommand command = new SqlCommand(_sqlQuery, conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Добавление прошло успешно");
                }

                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при внесении новых данных в таблицу: " + e.Message);
                Helper.Help();
            }
 
        }







    }
}
