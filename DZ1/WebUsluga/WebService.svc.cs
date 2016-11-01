using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ServiceModel;

namespace WebService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IWebService
    {
        private string PathToLogFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SensorWebServiceLog\\";
        private string LogFileName = "Log.txt";

        private static List<SensorInfo> RegisteredSensors = new List<SensorInfo>();
        private static List<Measurement> StoredMeasurements = new List<Measurement>();

        public Service()
        {
            if (!Directory.Exists(PathToLogFolder))
            {
                Directory.CreateDirectory(PathToLogFolder);
            }
        }

        public bool register(string username, double latitude, double longitude, string IPaddress, int port)
        {
            try
            {
                SensorInfo existingSensor = RegisteredSensors.Find(s => s.Username == username || (s.IPaddress == IPaddress && s.Port == port) || (s.Latitude == latitude && s.Longitude == longitude));

                if (existingSensor != null)
                {
                    SensorInfo newSensor = new SensorInfo() { Username = username, Latitude = latitude, Longitude = longitude, IPaddress = IPaddress, Port = port };
                    RegisteredSensors.Remove(existingSensor);
                    RegisteredSensors.Add(newSensor);
                    return true;
                }
                else
                {
                    SensorInfo newSensor = new SensorInfo() { Username = username, Latitude = latitude, Longitude = longitude, IPaddress = IPaddress, Port = port };
                    RegisteredSensors.Add(newSensor);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserAddress searchNeighbour(string username)
        {
            SensorInfo ClientSensor = RegisteredSensors.Find(x => x.Username == username);

            SensorInfo NeighbourSensor = RegisteredSensors.Where(x => x.Username != username).FirstOrDefault();

            UserAddress neighbourAddress;
            double MinDistance = double.MaxValue;

            if (NeighbourSensor == null || ClientSensor == null)
            {
                neighbourAddress = new UserAddress() { UserExists = false };
            }
            else
            {
                MinDistance = CalculateDistance(ClientSensor, NeighbourSensor);

                foreach (var Sensor in RegisteredSensors)
                {
                    double distance = CalculateDistance(ClientSensor, Sensor);
                    if (distance < MinDistance && distance != 0.0)
                    {
                        NeighbourSensor = Sensor;
                        MinDistance = distance;
                    }
                }

                neighbourAddress = new UserAddress() { UserExists = true, IPaddress = NeighbourSensor.IPaddress, Port = NeighbourSensor.Port, Name = NeighbourSensor.Username };
            }

            if (neighbourAddress.UserExists)
            {
                Log($"SEARCH: Client: {username.PadRight(20)} Neighbour: {NeighbourSensor.Username.PadRight(20)} Distance: {MinDistance:.1} | {DateTime.Now.ToString()}");
            }
            else
            {
                Log($"SEARCH: Client: {username.PadRight(20)} Neighbour: Not found | {DateTime.Now.ToString()}");

            }

            return neighbourAddress;
        }

        public bool storeMeasurement(string username, string parameter, float averageValue)
        {
            try
            {
                StoredMeasurements.Add(new Measurement(username, parameter, averageValue));
                Log($"MEASUREMENT: User: {username.PadRight(20)} Param: {parameter.PadRight(15)} Value: {averageValue.ToString().PadRight(5)} | {DateTime.Now.ToString()}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void sensorOffline(string IPaddress, int port)
        {
            RegisteredSensors.Remove(RegisteredSensors.Find(x => x.IPaddress == IPaddress &&  x.Port == port));
        }

        private double CalculateDistance(SensorInfo Sensor1, SensorInfo Sensor2)
        {
            const double R = 6371.0;
            double dlon, dlat, a, c, d;

            dlat = Sensor2.Latitude - Sensor1.Latitude;
            dlon = Sensor2.Longitude - Sensor2.Longitude; // a = (sin(dlat / 2)) ^ 2 + cos(lat1) * cos(lat2) * (sin(dlon / 2)) ^ 2 c = 2 * atan2(sqrt(a), sqrt(1 - a)) d = R * c
            a = Math.Pow(Math.Sin(dlat / 2.0), 2) + Math.Cos(Sensor1.Latitude) * Math.Cos(Sensor2.Latitude) * Math.Pow(Math.Sin(dlon / 2.0), 2);
            c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
            d = R * c;
            return d;
        }

        private void Log(string text)
        {
            using (FileStream LogFile = File.Open(PathToLogFolder + LogFileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter LogWriter = new StreamWriter(LogFile))
                {
                    LogWriter.WriteLine(text);
                }
            }
        }
    }

    public class SensorInfo
    {
        public string Username { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string IPaddress { get; set; }
        public int Port { get; set; }
    }
}
