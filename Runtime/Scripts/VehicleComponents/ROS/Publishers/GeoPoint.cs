using UnityEngine;
using RosMessageTypes.Geographic;
using Unity.Robotics.Core; //Clock

using SensorGPS = VehicleComponents.Sensors.GPS;
using VehicleComponents.ROS.Core;


namespace VehicleComponents.ROS.Publishers
{
    [RequireComponent(typeof(SensorGPS))]
    class GeoPoint: ROSPublisher<GeoPointMsg, SensorGPS>
    { 
        public double lat, lon;
        double easting, northing;

        void OnValidate()
        {
            ignoreSensorState = true;
        }

        public override void UpdateMessage()
        {        
            (easting, northing, lat, lon) = sensor.GetUTMLatLon();
            ROSMsg.latitude = lat;
            ROSMsg.longitude = lon;
        }
    }
}