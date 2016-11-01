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
            IDataProvider dataProvider = new CSVDataProvider(PathToCSV);
            ILogger consoleLogger = new ConsoleLogger();

            Console.Write("Enter sensor name: ");
            string username = Console.ReadLine().TrimEnd(new char[] { '\r', '\n' });

            Console.Write("Enter IP:Port : ");
            var ip_port = Console.ReadLine().TrimEnd(new char[] { '\r', '\n' }).Split(new char[] { ':' });

            string ipaddress = ip_port[0];
            int port = int.Parse(ip_port[1]);


            SensorClient sensor = new SensorClient(username, ipaddress, port, dataProvider, webService, consoleLogger);



            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - start measuring | 2 - stop measuring | 3 - exit");
                string command = Console.ReadLine().TrimEnd(new char[] { '\r', '\n' });

                switch (command)
                {
                    case "1":
                        sensor.StartMeasuring();
                        break;
                    case "2":
                        sensor.StopMeasuring();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Command doesn't exist.");
                        break;
                }
            }

        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void LogEvent(LogEventType eventType, string text)
        {
            Log(text);
        }
    }
}
