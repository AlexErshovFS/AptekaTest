using System;
using System.Data.SqlClient;
using System.Text;

namespace TestAStore
{
    class TableInfoSelectors
    {

        static StringBuilder _strBuilder = new StringBuilder();

        public static void ListTMC(string[] args)
        {

            {
                _strBuilder.Append("Select * FROM TMC  ");
                Output(_strBuilder.ToString());
            }

        }



        public static void ListStore(string[] args)
        {

            {

               
                _strBuilder.Append("SELECT Apteka.ID AS[Код], Apteka.Name AS[Аптека Имя ], Store.ID AS[Код], Store.Name AS[Склад] ");
                _strBuilder.Append("FROM Store RIGHT JOIN ");
                _strBuilder.Append("Apteka ON Store.ID_Apteka = Apteka.ID ");
                _strBuilder.Append("ORDER BY Apteka.Name ");

 
                Output(_strBuilder.ToString());
            }

        }


        public static void ListBatch(string[] args)
        {

            {
            

                _strBuilder.Append(" SELECT Apteka.Name as [Аптека],  Batch.ID as [Партия], TMC.Name_TMC as [Товар], Batch.Quantity as [Кол-во]");
                _strBuilder.Append("FROM            Batch INNER JOIN ");
                _strBuilder.Append(" Store ON Batch.ID_Store = Store.ID INNER JOIN ");
                _strBuilder.Append("   Apteka ON Store.ID_Apteka = Apteka.ID INNER JOIN ");
                _strBuilder.Append("   TMC ON Batch.ID_TMC = TMC.ID ");
                _strBuilder.Append($"WHERE(Apteka.ID = {args[1]}) ");
                _strBuilder.Append("ORDER BY TMC.Name_TMC ");



                Output(_strBuilder.ToString());
            }

        }


        public static void ListAptekaOst(string[] args)
        {

            {
                if (args.Length == 2)
                {      
                 
                _strBuilder.Append("SELECT TMC.Name_TMC, SUM(Batch.Quantity) AS [Остаток товара шт.] ");
                _strBuilder.Append("FROM Batch INNER JOIN ");
                _strBuilder.Append("Store ON Batch.ID_Store = Store.ID INNER JOIN ");
                _strBuilder.Append("Apteka ON Store.ID_Apteka = Apteka.ID INNER JOIN ");
                _strBuilder.Append("TMC ON Batch.ID_TMC = TMC.ID ");
                _strBuilder.Append($"WHERE(Apteka.ID = {args[1]}) ");
                _strBuilder.Append("GROUP BY TMC.Name_TMC ");
                _strBuilder.Append("ORDER BY TMC.Name_TMC ");


                Output(_strBuilder.ToString());
                }
                else
                {
                    Console.WriteLine("Неверно заданы аргументы");
                }








            }

        }





        static void Output(string _sqlQuery)
        {

           
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);
            try
            {

                conn.Open();

                using (SqlCommand command = new SqlCommand(_sqlQuery, conn))
                {
                    InfoOutput queryReader = new InfoOutput(command.ExecuteReader());
                    queryReader.InfoOnConsol();
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Helper.Help();
            }

        }



    }
}
