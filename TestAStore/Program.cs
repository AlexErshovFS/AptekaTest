using System;
using System.Collections.Generic;

namespace TestAStore
{
    class Program
    {



        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Helper.Help();
                
                return;
            }

            var command = args[0];

            if (!_commandMap.ContainsKey(command))
            {
                Console.WriteLine("Несуществующая команда");
                Helper.Help();
            }
            else
            {
                _commandMap[command](args);
            }
        }




        private static readonly Dictionary<string, Action<string[]>> _commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
        {


            ["InsApteka"] = TableUpdate.InsApteka,
            ["InsStore"] = TableUpdate.InsStore,
            ["InsBatch"] = TableUpdate.InsBatch,
            ["InsTMC"] = TableUpdate.InsTMC,

            ["ListTMC"] = TableInfoSelectors.ListTMC,
            ["ListAptekaOst"] = TableInfoSelectors.ListAptekaOst,
            ["ListStore"] = TableInfoSelectors.ListStore,
            ["ListBatch"] = TableInfoSelectors.ListBatch,

            ["DelTMC"] = TableDelete.DelTMC,
            ["DelStore"] = TableDelete.DelStore,
            ["DelBatch"] = TableDelete.DelBatch,
            ["DelApteka"] = TableDelete.DelApteka,

            ["SetConnection"] = Connection.SetConnection



        };





    }
}
