using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor
{
    public class RandomLineGenerator : ILineNumberGenerator
    {
        private DateTime startTime { get; set; }
        private int secondsActive { get; set; }
        public RandomLineGenerator()
        {
            startTime = DateTime.Now;
        }
        public int GetRandomNumber()
        {
            secondsActive = (startTime - DateTime.Now).Seconds;

            return (secondsActive % 100) + 2;
        }
    }
}
