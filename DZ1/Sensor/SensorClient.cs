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

        private DateTime _startTime;
        private int lastLineNumber;

        private bool isRegistered = false;
        private bool measuringState = false;
        private bool sendZeroes = true;

        private IWebService _WebService;
        private IDataProvider _DataProvider;
        private ILogger _Logger;

        private TcpListener _server;
        private TcpClient NeighbourClient;

        private UserAddress neighborSensor;
        

        public bool IsRegistered
        {
            get
            {
                return isRegistered;
            }
            set
            {
                isRegistered = value;
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

        public TimeSpan TimeActive
        {
            get { return (DateTime.Now - _startTime); }
        }

        public UserAddress NeighborSensor
        {
            get
            {
                return neighborSensor;
            }

            set
            {
                neighborSensor = value;
            }
        }

        public int LastLineNumber
        {
            get
            {
                return lastLineNumber;
            }

            set
            {
                lastLineNumber = value;
            }
        }

        public bool MeasuringState
        {
            get
            {
                return measuringState;
            }

            set
            {
                measuringState = value;
            }
        }

        public bool SendZeroes
        {
            get
            {
                return sendZeroes;
            }

            set
            {
                sendZeroes = value;
            }
        }

        public SensorClient(string username, string ipaddress, int port, IDataProvider dataProvider, IWebService webService, ILogger logger)
        {
            _WebService = webService;
            _DataProvider = dataProvider;
            _Logger = logger;

            Username = username;
            IPaddress = ipaddress;
            Port = port;

            SetNeighbour(new UserAddress() { UserExists = false });

            _startTime = DateTime.Now; // Save start time

            SetLatLon(); // Generate Latitude and Longitude

            Register(); // Register sensor with web-service

            StartServer();

        }

        public string GetInfo()
        {
            return $"Sensor {Username} at {IPaddress}:{Port} | Lat: {Latitude} Lon: {Longitude}";
        }
        private void SetNeighbour(UserAddress neighbour)
        {
            if(NeighborSensor == null)
            {
                NeighborSensor = new UserAddress() { UserExists = false };
            }

            NeighborSensor.UserExists = neighbour.UserExists;
            NeighborSensor.IPaddress = neighbour.IPaddress;
            NeighborSensor.Port = neighbour.Port;
            NeighborSensor.Name = neighbour.Name;
        }
        private int GetRandomIndex()
        {
            int secondsActive = TimeActive.Seconds;
            return (secondsActive % 100) + 2;
        }
        private SensorData GetSensorData()
        {
            LastLineNumber = GetRandomIndex();
            SensorData data = _DataProvider.GetDataAtIndex(LastLineNumber);
            return data;
        }

        private void SetLatLon()
        {
            Random rand = new Random();
            Latitude = 45.0 + (rand.Next(75, 85) / 100.0); // [45.75, 45.85]
            Longitude = 15.0 + (rand.Next(87, 100) / 100.0); // [15.87, 16.00]
        }

        #region Sensor Activity Control Methods

        public async Task StartMeasuring()
        {
            MeasuringState = true;
            while (MeasuringState)
            {
                await Measure();
                await Task.Delay(1000);
            }
        }

        public void StopMeasuring()
        {
            MeasuringState = false;
        }

        #endregion

        #region Service Communication
        private bool Register()
        {
            IsRegistered = _WebService.register(Username, Latitude, Longitude, IPaddress, Port);

            if (IsRegistered)
            {
                _Logger.LogEvent(LogEventType.Registration, "Registered Successfully");
            }
            else
            {
                _Logger.LogEvent(LogEventType.Registration, "Registration Not Successful");
            }

            return IsRegistered;
        }

        private async Task FindNeighbor()
        {
            SetNeighbour(new UserAddress() { UserExists = false });

            while (NeighborSensor.UserExists == false)
            {
                SetNeighbour(await _WebService.searchNeighbourAsync(Username));

                if (neighborSensor.UserExists)
                {
                    _Logger.LogEvent(LogEventType.Neighbour, $"Neighbour: {NeighborSensor.Name} at {NeighborSensor.IPaddress}:{NeighborSensor.Port}");
                }
                else
                {
                    _Logger.LogEvent(LogEventType.Neighbour, $"Neighbour doesn't exist");
                    await Task.Delay(2500);
                }
            }
        }

        private async void StoreMeasurement(SensorData normalizedMeasurement)
        {
            if (normalizedMeasurement.Temperature != 0.0 || SendZeroes)
            {
                float measurement = (float) normalizedMeasurement.Temperature;
                while (await _WebService.storeMeasurementAsync(Username, "Temperature", measurement) != true) ;
            }

            if (normalizedMeasurement.Pressure != 0.0 || SendZeroes)
            {
                float measurement = (float)normalizedMeasurement.Pressure;
                while (await _WebService.storeMeasurementAsync(Username, "Pressure", measurement) != true) ;
            }

            if (normalizedMeasurement.Humidity != 0.0 || SendZeroes)
            {
                float measurement = (float)normalizedMeasurement.Humidity;
                while (await _WebService.storeMeasurementAsync(Username, "Humidity", measurement) != true) ;
            }

            if (normalizedMeasurement.CO != 0.0 || SendZeroes)
            {
                float measurement = (float)normalizedMeasurement.CO;
                while (await _WebService.storeMeasurementAsync(Username, "CO", measurement) != true) ;
            }

            if (normalizedMeasurement.NO2 != 0.0 || SendZeroes)
            {
                float measurement = (float)normalizedMeasurement.NO2;
                while (await _WebService.storeMeasurementAsync(Username, "NO2", measurement) != true) ;
            }

            if (normalizedMeasurement.SO2 != 0.0 || SendZeroes)
            {
                float measurement = (float)normalizedMeasurement.SO2;
                while (await _WebService.storeMeasurementAsync(Username, "SO2", measurement) != true) ;
            }
        }

        private double NormalizeMeasurement(double myData, double neighbourData)
        {
            if (neighbourData == 0.0)
            {
                return myData;
            }
            if(myData == 0.0)
            {
                return myData;
            }
            else
            {
                return (myData + neighbourData) / 2;
            }
        }

        private SensorData GetNormalizedMeasurement(SensorData myData, SensorData neighbourData)
        {
            SensorData normalizedMeasurement = new SensorData();

            normalizedMeasurement.Temperature = NormalizeMeasurement(myData.Temperature, neighbourData.Temperature);
            normalizedMeasurement.Pressure = NormalizeMeasurement(myData.Pressure, neighbourData.Pressure);
            normalizedMeasurement.Humidity = NormalizeMeasurement(myData.Humidity, neighbourData.Humidity);
            normalizedMeasurement.CO = NormalizeMeasurement(myData.CO, neighbourData.CO);
            normalizedMeasurement.NO2 = NormalizeMeasurement(myData.NO2, neighbourData.NO2);
            normalizedMeasurement.SO2 = NormalizeMeasurement(myData.SO2, neighbourData.SO2);

            return normalizedMeasurement;
        }
        #endregion

        #region TCP Communication
        private async Task StartServer()
        {
            _server = new TcpListener(IPAddress.Parse(IPaddress), Port);

            try
            {
                _server.Start();

                while (true)
                {
                    TcpClient newClient = await _server.AcceptTcpClientAsync();
                    ReceiveRequest(newClient);                    
                }
            }
            finally
            {
                _server.Stop();
            }
           
        }

        private async Task ConnectToNeighbour()
        {

            while (NeighbourClient == null || !NeighbourClient.Connected)
            {
                await FindNeighbor();

                try
                {
                    NeighbourClient = new TcpClient();
                    NeighbourClient.Connect(IPAddress.Parse(NeighborSensor.IPaddress), NeighborSensor.Port);
                }
                catch (Exception)
                {
                    _WebService.sensorOffline(NeighborSensor.IPaddress, NeighborSensor.Port);
                }
            }
        }

        private async Task Measure()
        {
            bool finishedMeasurement = false;

            while (!finishedMeasurement)
            {
                if (NeighbourClient == null || !NeighbourClient.Connected)
                {
                    await ConnectToNeighbour();
                }
                else
                {
                    try
                    {
                        SensorData myData = GetSensorData();

                        await SendRequest(RequestType.SensorData);
                        SensorData neighbourData = await ReceiveResponse();
                        
                        SensorData normalizedData = GetNormalizedMeasurement(myData, neighbourData);

                        StoreMeasurement(normalizedData);

                        _Logger.LogEvent(LogEventType.MeasuredData, $"Line: {LastLineNumber} Active: {TimeActive.Seconds}s" + Environment.NewLine + $"Measurement: {myData}");

                        finishedMeasurement = true;
                    }
                    catch (Exception ex)
                    {
                        _Logger.LogEvent(LogEventType.Error, ex.Message);
                    }
                }
            }
        }

        #region SendDataToNeighbourClient
        private async Task ReceiveRequest(TcpClient client)
        {
            byte[] request = new byte[1024];
            int bytesRead = 0;

            using (client)
            {
                using (NetworkStream stream = client.GetStream())
                {
                    while (client.Connected)
                    {
                        bytesRead = await stream.ReadAsync(request, 0, sizeof(RequestType));

                        if(bytesRead == 0)
                        {
                            client.Close();
                            break;
                        }

                        RequestType receivedRequestType = (RequestType)BitConverter.ToInt32(request, 0);

                        _Logger.LogEvent(LogEventType.RequestReceived, $"Received request for {receivedRequestType} from {client.Client.RemoteEndPoint}");

                        switch (receivedRequestType)
                        {
                            case RequestType.SensorData:
                                await SendResponse(stream, ResponseType.SensorData);
                                break;
                            case RequestType.Disconnect:
                                client.Close();
                                break;
                        }

                    }
                }
            }

        }

        public async Task SendResponse(NetworkStream stream, ResponseType responseType)
        {
            switch (responseType)
            {
                case ResponseType.SensorData:
                    byte[] response = GetSensorDataResponse();
                    await stream.WriteAsync(response, 0, response.Length);
                    break;
            }

        }

        private byte[] GetSensorDataResponse()
        {
            byte[] response = BitConverter.GetBytes((int)ResponseType.SensorData);
            SensorData data = GetSensorData();
            response = response.Concat(data.Serialize()).ToArray();

            return response;
        }

        

        #endregion

        #region AskForDataFromNeighbour
        public async Task SendRequest(RequestType requestType)
        {
            try
            {
                NetworkStream stream = NeighbourClient.GetStream();

                byte[] request = BitConverter.GetBytes((int)requestType);
                await stream.WriteAsync(request, 0, request.Length);

                _Logger.LogEvent(LogEventType.RequestSent, $"Sent request for {requestType} to: {NeighborSensor.IPaddress}:{NeighborSensor.Port}");

                switch (requestType)
                {
                    case RequestType.SensorData:
                        break;
                    case RequestType.Disconnect:
                        NeighbourClient.Close();
                        break;
                }
            }
            catch (Exception)
            {
                throw new Exception("Connection closed unexpectedly.");
            }

        }
        private async Task<SensorData> ReceiveResponse()
        {
            NetworkStream stream = NeighbourClient.GetStream();
            byte[] response = new byte[1024];

            int bytesRead = await stream.ReadAsync(response, 0, 1024);

            if (bytesRead != 0)
            {
                ResponseType receivedResponseType = (ResponseType)BitConverter.ToInt32(response, 0);

                switch (receivedResponseType)
                {
                    case ResponseType.SensorData:
                        byte[] responseData = response.Skip(sizeof(ResponseType)).ToArray();
                        SensorData data = SensorData.Deserialize(responseData);
                        return data;
                    default:
                        throw new Exception("Received unhandled response type.");
                }
            }
            else
            {
                NeighbourClient.Close();
                throw new Exception("Connection closed unexpectedly.");
            }

        }
        #endregion

        #endregion
    }

    public enum RequestType{
        SensorData = 01,
        Disconnect = 02
    }

    public enum ResponseType
    {
        SensorData = 01
    }

}
