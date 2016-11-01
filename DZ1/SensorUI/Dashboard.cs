using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sensor;

namespace SensorUI
{
    public partial class Dashboard : Form
    {
        private string Username { get; set; }
        private string IPaddress { get; set; }
        private int Port { get; set; }
        private SensorClient sensor { get; set; }
        private SensorUILogger sensorUILogger { get; set; }
        private IDataProvider DataProvider { get; set; }
        private Sensor.Service.IWebService WebService { get; set; }

        public Dashboard(string username, string ipaddress, int port, IDataProvider dataProvider, Sensor.Service.IWebService webService)
        {
            InitializeComponent();

            Username = username;
            IPaddress = ipaddress;
            Port = port;
            DataProvider = dataProvider;
            WebService = webService;
        }

        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            sensorUILogger = new SensorUILogger(MainLog, RequestLog);

            try
            {
                sensor = new SensorClient(Username, IPaddress, Port, DataProvider, WebService, sensorUILogger);

                if( sensor.SensorWorking == false)
                {
                    MessageBox.Show("Unable to create sensor with given data.");
                    sensor.Shutdown();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create sensor with given data.");
                sensor.Shutdown();
                Dispose();
            }

            userAddressBindingSource.DataSource = sensor.NeighborSensor;

            SensorName.Text = sensor.Username;
            IP.Text = $"{sensor.IPaddress}:{sensor.Port}";

            Text = $"Sensor Dashboard - {sensor.Username} - {sensor.IPaddress}:{sensor.Port}";
        }

        private async void MeasureButton_Click(object sender, EventArgs e)
        {
            await sensor.StartMeasuring();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            sensor.StopMeasuring();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            sensor?.Shutdown();
        }
    }

    public class SensorUILogger : ILogger
    {
        private Label MainLogElement { get; set; }
        private Label RequestLogElement { get; set; }

        private List<LogEventType> LoggedEventTypes = new List<LogEventType>() {
            LogEventType.Error,
            LogEventType.Registration,
            LogEventType.MeasuredData,
            LogEventType.Neighbour,
            LogEventType.RequestReceived,
            LogEventType.RequestSent
        };

        public SensorUILogger(Label mainLogElement, Label requestLogElement)
        {
            MainLogElement = mainLogElement;
            RequestLogElement = requestLogElement;
        }
        public void Log(string text)
        {
            MainLogElement.Text = text;
        }

        public void LogEvent(LogEventType eventType, string text)
        {
            if (LoggedEventTypes.Contains(eventType))
            {
                switch (eventType)
                {
                    case LogEventType.RequestReceived:
                        RequestLogElement.Text = text;
                        break;
                    default:
                        Log(text);
                        break;
                }
            }
        }
    }
}
