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

        private List<Form> spawnedDashoards = new List<Form>();

        private Sensor.Service.IWebService webService { get; set; }
        private IDataProvider dataProvider { get; set; }
        private ILogger sensorUILogger { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            webService = new Sensor.Service.WebServiceClient();
            dataProvider = new CSVDataProvider(PathToCSV);
        }
        private void CreateSensor_Click(object sender, EventArgs e)
        {
            var newSensorDashboard = new Dashboard(SensorNameTextbox.Text, "127.0.0.1", (int)PortInput.Value, dataProvider, webService);

            newSensorDashboard.Show();
            newSensorDashboard.Activate();

            spawnedDashoards.Add(newSensorDashboard);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var dasboard in spawnedDashoards)
            {
                dasboard.Dispose();
            }
        }
    }
}
