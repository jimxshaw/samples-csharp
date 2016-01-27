using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTankApp.Options
{
    // This class contains properties of the key names used 
    // in alertThreshold.json.  
    public class ThresholdOptions
    {
        public int WaterTemperatureMax { get; set; }
        public int WaterTemperatureMin { get; set; }
        public int FishMotionMin { get; set; }
        public int FishMotionMax { get; set; }
        public int WaterOpacityMin { get; set; }
        public int WaterOpacityMax { get; set; }
        public int LightIntensityMin { get; set; }
        public int LightIntensityMax { get; set; }
    }

}
