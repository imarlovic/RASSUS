using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    public class SensorData
    {
        private double temperature;
        private double pressure;
        private double humidity;
        private double co;
        private double no2;
        private double co2;

        public double Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }

        public double Pressure
        {
            get
            {
                return pressure;
            }

            set
            {
                pressure = value;
            }
        }

        public double Humidity
        {
            get
            {
                return humidity;
            }

            set
            {
                humidity = value;
            }
        }

        public double CO
        {
            get
            {
                return co;
            }

            set
            {
                co = value;
            }
        }

        public double NO2
        {
            get
            {
                return no2;
            }

            set
            {
                no2 = value;
            }
        }

        public double CO2
        {
            get
            {
                return co2;
            }

            set
            {
                co2 = value;
            }
        }
    }
}
