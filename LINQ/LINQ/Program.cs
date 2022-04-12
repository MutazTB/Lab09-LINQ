using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");

            UnitOfWork unit = new UnitOfWork();
            MapBox mabPox = new MapBox();
            unit.AllNeighborhoods(mabPox);
            Console.WriteLine();
            //unit.NamesNeighborhoods(mabPox);
            //unit.RemoveDuplicates(mabPox);
            //unit.OneSingleQuery(mabPox);
            unit.OpposingMethod(mabPox);

        }
    }
}
