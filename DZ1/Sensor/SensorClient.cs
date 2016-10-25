using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Sensor.Service;
using System.Net.Sockets;
using System.Threading;

namespace Sensor
{
    public class SensorClient
    {
        private string username;
        private string ipaddress;
        private int port;
        private double latitude;
        private double longitude;

        private bool _IsRegistered = false;

        private WebServiceClient _WebServiceClient;

        public bool IsRegistered
        {
            get
            {
                return _IsRegistered;
            }
            set
            {
                _IsRegistered = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public string IPaddress
        {
            get
            {
                return ipaddress;
            }

            set
            {
                ipaddress = value;
            }
        }

        

        public SensorClient(string username, string ipaddress, int port)
        {
            _WebServiceClient = new WebServiceClient();

            Username = username;
            IPaddress = ipaddress;
            Port = port;
            SetLatLon(); // Generate Latitude and Longitude

            Register(); // Register sensor

        }

        public bool Register()
        {
            IsRegistered = _WebServiceClient.register(Username, Latitude, Longitude, IPaddress, Port);

            if (IsRegistered)
            {
                Console.WriteLine(GetInfo() + Environment.NewLine + "Registered Successfully!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(GetInfo() + Environment.NewLine + "Registration Not Successful!" + Environment.NewLine);
            }

            return IsRegistered;
        }

        public string GetStatus()
        {
            return "Sensor status: " + (IsRegistered ? "Registered" : "Not Registered");
        }

        public string GetInfo()
        {
            return string.Format("SENSOR: usr: {0} | ip: {1} | port: {2} | lat: {3} | lon: {4}", Username, IPaddress, Port, Latitude, Longitude);
        }

        public void FindNeighbor()
        {
            UserAddress neighborSensor = _WebServiceClient.searchNeighbour(Username);

            if (neighborSensor.UserExists)
            {
                Console.WriteLine(string.Format("usr: {0} -> My neighbour is at {1}:{2}", Username, neighborSensor.IPaddress, neighborSensor.Port));
            }
            else
            {
                Console.WriteLine(string.Format("usr: {0} -> Web service couldn't find my neighbour", Username));
            }
        }

        private void SetLatLon()
        {
            Random rand = new Random();
            Latitude = 45.0 + (rand.Next(75, 85) / 100.0); // [45.75, 45.85]
            Longitude = 15.0 + (rand.Next(87, 100) / 100.0); // [15.87, 16.00]
        }

    }
}
