using System;

using System.Data.SqlClient;
using System.Text;

namespace TestAStore
{
    class InfoOutput
    {
        SqlDataReader _queryReader;
        StringBuilder _strBuilder = new StringBuilder();

        public InfoOutput(SqlDataReader _reader)
        {
            _queryReader = _reader;
        }



        public void InfoOnConsol()
        {
            int i = 0;

            if (_queryReader.HasRows)
            {
                for (i = 0; i < _queryReader.FieldCount - 1; i++)
                {
                    _strBuilder.Append(_queryReader.GetName(i) + "\t");

                }
                _strBuilder.Append(_queryReader.GetName(i));
                Console.WriteLine(_strBuilder.ToString());
                 
                while (_queryReader.Read())  
                {

                    if (_strBuilder.Length > 0) { _strBuilder.Remove(0, _strBuilder.Length); }

                    for (i = 0; i < _queryReader.FieldCount - 1; i++)
                    {
                        _strBuilder.Append(_queryReader.GetValue(i) + "\t");
                    }
                    _strBuilder.Append(_queryReader.GetValue(i));

                    Console.WriteLine(_strBuilder.ToString());

                }

               
            }



        }






    }
}
