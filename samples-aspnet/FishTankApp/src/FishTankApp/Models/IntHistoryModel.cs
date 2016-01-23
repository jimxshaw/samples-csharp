using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FishTankApp.Models
{
    public class IntHistoryModel
    {
        public DateTime TimeStamp { get; set; }
        public int Value { get; set; }

        public IntHistoryModel(DateTime timeStamp, int value)
        {
            TimeStamp = timeStamp;
            Value = value;
        }
    }
}
