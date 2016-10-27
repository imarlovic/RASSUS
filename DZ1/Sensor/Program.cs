using Sensor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sensor
{
    public class Program
    {
        private const string PathToCSV = "C:\\Users\\imarl\\OneDrive\\FER\\Raspodijeljeni sustavi\\Domaće zadaće\\DZ1\\Data\\mjerenja.csv";

        public static void Main(string[] args)
        {
            IWebService webService = new WebServiceClient();
            ILineNumberGenerator lineNumberGenerator = new RandomLineGenerator();
            IDataProvider dataProvider = new CSVDataProvider(PathToCSV, lineNumberGenerator);

            SensorClient sensor1 = new SensorClient("sensor1", "localhost", 55501, dataProvider, webService);
            SensorClient sensor2 = new SensorClient("sensor2", "localhost", 55502, dataProvider, webService);

            Thread.Sleep(1000);

            sensor1.FindNeighbor();
            sensor2.FindNeighbor();

            Console.ReadLine();
        }
    }
}
