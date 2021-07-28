using System;
using Google.Protobuf.WellKnownTypes;

// needs to be the same namespace as the /Protos/weather.proto file: INTERNAL PARTIAL CLASS
namespace ApiGrpc.Protos
{
    // Properties for the underlying data are generated from the .proto file
    // This partial class just adds some extra convenience properties
    internal partial class WeatherForecast
    {
        public DateTime DateTime
        {
            get => Date.ToDateTime();
            set { Date = Timestamp.FromDateTime(value.ToUniversalTime()); }
        }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
