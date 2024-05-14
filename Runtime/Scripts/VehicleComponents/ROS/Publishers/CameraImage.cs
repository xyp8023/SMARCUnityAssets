using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.Core; //Clock

using CameraImageSensor = VehicleComponents.Sensors.CameraImage;

namespace VehicleComponents.ROS.Publishers
{
    [RequireComponent(typeof(CameraImageSensor))]
    class CameraImage: SensorPublisher<ImageMsg, CameraImageSensor>
    {
        void Start()
        {
            var textureHeight = sensor.textureHeight;
            var textureWidth = sensor.textureWidth;

            ROSMsg.data = new byte[textureHeight * textureWidth * 3];
            ROSMsg.encoding = "rgb8";
            ROSMsg.height = (uint) textureHeight;
            ROSMsg.width = (uint) textureWidth;
            ROSMsg.is_bigendian = 0;
            ROSMsg.step = (uint)(3*textureWidth);
            ROSMsg.header.frame_id = sensor.linkName;
        }

        public override void UpdateMessage()
        {
            var img = sensor.image.GetRawTextureData<byte>();
            for(int i=0; i<img.Length; i++) ROSMsg.data[i] = img[i]; 
            ROSMsg.header.stamp = new TimeStamp(Clock.time);
        }
    }
}