using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sensor
{
    public class CSVDataProvider : IDataProvider
    {
        private StreamReader csv;
        private List<List<double>> RawDataList;
        private List<SensorData> SensorDataList;

        public CSVDataProvider(string path)
        {
            csv = new StreamReader(path);

            string csvdata = csv.ReadToEnd();

            var lines = csvdata.Split(new char[]{ '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                .Skip(1) //Header -> Temperature,Pressure,Humidity,CO,NO2,SO2
                                .Select(x => x.Split(new char[] { ',' }))
                                .ToList();

            RawDataList = lines.Select(x => x.Select(y => (y == string.Empty ? 0.0 : double.Parse(y))).ToList()).ToList();
            SensorDataList = RawDataList.Select(x => ConvertRawDataToSensorData(x)).ToList();

        }

        public SensorData GetDataAtIndex(int index)
        {   
            if(index < SensorDataList.Count)
            {
                return SensorDataList[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("csv file does not have data at specified line");
            }            
            
        }

        private SensorData ConvertRawDataToSensorData(List<double> RawData)
        {
            return new SensorData() { Temperature = RawData[0], Pressure = RawData[1], Humidity = RawData[2], CO = RawData[3], NO2 = RawData[4], CO2 = RawData[5] };
        }
    }
}
