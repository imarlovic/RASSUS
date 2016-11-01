using Sensor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorUI
{
    public partial class MainWindow : Form
    {
        private const string PathToCSV = "C:\\Users\\imarl\\OneDrive\\FER\\Raspodijeljeni sustavi\\Domaće zadaće\\DZ1\\Data\\mjerenja.csv";
        private string username { get; set; }
        private string ipaddress { get; set; }
        private int port { get; set; }

        private Sensor.Service.IWebService webService { get; set; }
        private IDataProvider dataProvider { get; set; }
        private ILogger sensorUILogger { get; set; }

        private SensorClient sensor { get; set; }



        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            webService = new Sensor.Service.WebServiceClient();
            dataProvider = new CSVDataProvider(PathToCSV);
            sensorUILogger = new SensorUILogger(MainLog, RequestLog);
        }

        private async void MeasureButton_Click(object sender, EventArgs e)
        {
            await sensor.StartMeasuring();
        }

        private void CreateSensor_Click(object sender, EventArgs e)
        {
            sensor = new SensorClient(SensorNameTextbox.Text, "127.0.0.1", (int)PortInput.Value, dataProvider, webService, sensorUILogger);

            SensorNameTextbox.Enabled = false;
            PortInput.Enabled = false;

            Text = $"SensorUI - {sensor.Username} - {sensor.IPaddress}:{sensor.Port}";

            userAddressBindingSource.DataSource = sensor.NeighborSensor;
            

            MeasureButton.Enabled = true;
            StopButton.Enabled = true;

        }

        private void StopButton_Click(object sender, EventArgs e)
        {

            sensor.StopMeasuring();

            //sensor = null;
            //SensorNameTextbox.ResetText();
            //PortInput.ResetText();
            //SensorNameTextbox.Enabled = true;
            //PortInput.Enabled = true;
            //InfoLabel.ResetText();

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
