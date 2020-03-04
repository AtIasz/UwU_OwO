using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Server
{
    public class Celsius : ISerializable
    {
        public int _id { get; set; }
        public int _value { get; set; }
        public int _timeInSeconds { get; set; }
        public Celsius(int id,int value,int timeInSeconds)
        {
            _id = id;
            _value = value;
            _timeInSeconds = timeInSeconds;
        }
        public Celsius()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        
    }
}
