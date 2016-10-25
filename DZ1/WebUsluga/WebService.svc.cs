using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    public class Service : IWebService
    {

        private static List<SensorInfo> RegisteredSensors = new List<SensorInfo>();

        public bool register(string username, double latitude, double longitude, string IPaddress, int port)
        {
            if(RegisteredSensors.Exists(s => s.Username == username || ( s.IPaddress == IPaddress  && s.Port == port) || (s.Latitude == latitude && s.Longitude == longitude)))
            {
                return false;
            }
            else
            {
                SensorInfo newSensor = new SensorInfo() { Username = username, Latitude = latitude, Longitude = longitude, IPaddress = IPaddress, Port = port };
                RegisteredSensors.Add(newSensor);
                return true;
            }
        }

        public UserAddress searchNeighbour(string username)
        {
            SensorInfo ClientSensor = RegisteredSensors.Find(x => x.Username == username);

            SensorInfo NeighbourSensor = RegisteredSensors.Where(x => x.Username != username).FirstOrDefault();

            if (NeighbourSensor == null)
            {
                return new UserAddress() { UserExists = false };
            }

            double MinDistance = CalculateDistance(ClientSensor, NeighbourSensor);

            foreach (var Sensor in RegisteredSensors)
            {
                double distance = CalculateDistance(ClientSensor, Sensor);
                if (distance < MinDistance)
                {
                    NeighbourSensor = Sensor;
                    MinDistance = distance;
                }
            }

            return new UserAddress() { UserExists = true, IPaddress = NeighbourSensor.IPaddress, Port = NeighbourSensor.Port };

        }

        public bool storeMeasurement(string username, string parameter, float averageValue)
        {
            throw new NotImplementedException();
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
