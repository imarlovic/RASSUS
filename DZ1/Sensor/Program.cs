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
        public static void Main(string[] args)
        {

            IDataProvider data = new CSVDataProvider("C:\\Users\\imarl\\OneDrive\\FER\\Raspodijeljeni sustavi\\Domaće zadaće\\DZ1\\Data\\mjerenja.csv");

            SensorClient sensor1 = new SensorClient("sensor1", "localhost", 55501);
            SensorClient sensor2 = new SensorClient("sensor2", "localhost", 55502);

            Thread.Sleep(1000);

            sensor1.FindNeighbor();
            sensor2.FindNeighbor();

            Console.ReadLine();
        }
    }
}
