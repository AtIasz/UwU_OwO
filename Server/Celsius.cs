using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Celsius
    {
        int _id { get; set; }
        int _value { get; set; }
        int _timeInSeconds { get; set; }
        public Celsius(int id,int value,int timeInSeconds)
        {
            _id = id;
            _value = value;
            _timeInSeconds = timeInSeconds;
        }
        public Celsius()
        {

        }
    }
}
