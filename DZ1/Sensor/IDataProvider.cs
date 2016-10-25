using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    interface IDataProvider
    {
        SensorData GetDataAtIndex(int index);
    }
}
