
using System;
using System.Data.SqlClient;
using System.Text;


namespace TestAStore
{

    class TableDelete
    {
        static StringBuilder _strBuilder = new StringBuilder();

        public static void DelTMC(string[] args)
        {
            if (args.Length == 2)
            {
                _strBuilder.Append($"DELETE  FROM TMC WHERE ID = {args[1]}");
                 
                Delete(_strBuilder.ToString());
            }

        }

        public static void DelStore(string[] args)
        {
            if (args.Length == 2)
            {
                _strBuilder.Append($"DELETE  FROM Store WHERE ID = {args[1]}");

                Delete(_strBuilder.ToString());
            }

        }

        public static void DelBatch(string[] args)
        {
            if (args.Length == 2)
            {
                _strBuilder.Append($"DELETE  FROM Batch WHERE ID = {args[1]}");

                Delete(_strBuilder.ToString());
            }

        }

        public static void DelApteka(string[] args)
        {
            if (args.Length == 2)
            {
                _strBuilder.Append($"DELETE  FROM Apteka WHERE ID = {args[1]}");

                Delete(_strBuilder.ToString());
            }

        }








        static void Delete(string _sqlQuery)
        {

 

            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            try
            {

                conn.Open();

                using (SqlCommand command = new SqlCommand(_sqlQuery, conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Удаление прошло успешно");
                }

                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при удалении данных из теблицы: " + e.Message);
                Helper.Help();
            }

        }








    }
}
