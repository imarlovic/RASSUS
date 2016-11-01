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
        private double so2;

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

        public double SO2
        {
            get
            {
                return so2;
            }

            set
            {
                so2 = value;
            }
        }

        public byte[] Serialize()
        {
            double[] values = new double[] { Temperature, Pressure, Humidity, CO, NO2, SO2 };

            byte[] data = values.SelectMany(value => BitConverter.GetBytes(value)).ToArray();

            return data;
        }

        public static SensorData Deserialize(byte[] data)
        {
            SensorData newSensorData = new SensorData();

            newSensorData.Temperature = BitConverter.ToDouble(data, sizeof(double) * 0);
            newSensorData.Pressure =    BitConverter.ToDouble(data, sizeof(double) * 1);
            newSensorData.Humidity =    BitConverter.ToDouble(data, sizeof(double) * 2);
            newSensorData.CO =          BitConverter.ToDouble(data, sizeof(double) * 3);
            newSensorData.NO2 =         BitConverter.ToDouble(data, sizeof(double) * 4);
            newSensorData.SO2 =         BitConverter.ToDouble(data, sizeof(double) * 5);

            return newSensorData;
        }

        public override string ToString()
        {
            return $"Temp: {Temperature} Press: {Pressure} Hum: {Humidity} CO: {CO} NO2: {NO2} SO2: {SO2}";
        }
    }
}
