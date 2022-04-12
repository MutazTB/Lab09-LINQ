using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class UnitOfWork
    {

        static string path = "../../../data.json";

        static string readingData = File.ReadAllText(path);

        MapBox mabPox = JsonConvert.DeserializeObject<MapBox>(readingData);

        public void AllNeighborhoods(MapBox mapbox)
        {            
            Console.WriteLine("Output all of the neighborhoods.");
            int count = 0;
            
            var allNeighborhoods = from data in mabPox.features select data.properties.neighborhood;

            foreach (var item in allNeighborhoods)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }

        public void NamesNeighborhoods(MapBox mapbox)
        {
            Console.WriteLine("Filter out all the neighborhoods that do not have any names.");
            int count = 0;

            var allNeighborhoods = from data in mabPox.features 
                                   where data.properties.neighborhood !="" 
                                   select data.properties.neighborhood;

            foreach (var item in allNeighborhoods)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }

        public void RemoveDuplicates(MapBox mapbox)
        {
            Console.WriteLine("Remove the duplicates.");
            int count = 0;

            var allNeighborhoods = from data in mabPox.features
                                   where data.properties.neighborhood != ""
                                   select data.properties.neighborhood;
            var distinctList = allNeighborhoods.Distinct();
            
            foreach (var item in distinctList)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }

        public void OneSingleQuery(MapBox mapbox)
        {
            Console.WriteLine("one single query.");
            int count = 0;

            var allNeighborhoods = (from data in mabPox.features
                                   where data.properties.neighborhood != ""
                                   select data.properties.neighborhood).Distinct(); 
            
            foreach (var item in allNeighborhoods)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }

        public void OpposingMethod(MapBox mapbox)
        {
            Console.WriteLine("using the opposing method.");
            int count = 0;

            var allNeighborhoods = mabPox.features.Select(x => x.properties.neighborhood).Where(y => y != "") .Distinct();

            foreach (var item in allNeighborhoods)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }


    }
}
