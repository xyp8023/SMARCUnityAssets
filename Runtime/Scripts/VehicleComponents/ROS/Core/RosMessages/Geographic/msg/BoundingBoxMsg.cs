//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geographic
{
    [Serializable]
    public class BoundingBoxMsg : Message
    {
        public const string k_RosMessageName = "geographic_msgs/BoundingBox";
        public override string RosMessageName => k_RosMessageName;

        //  Geographic map bounding box. 
        // 
        //  The two GeoPoints denote diagonally opposite corners of the box.
        // 
        //  If min_pt.latitude is NaN, the bounding box is "global", matching
        //  any valid latitude, longitude and altitude.
        // 
        //  If min_pt.altitude is NaN, the bounding box is two-dimensional and
        //  matches any altitude within the specified latitude and longitude
        //  range.
        public GeoPointMsg min_pt;
        //  lowest and most Southwestern corner
        public GeoPointMsg max_pt;
        //  highest and most Northeastern corner

        public BoundingBoxMsg()
        {
            this.min_pt = new GeoPointMsg();
            this.max_pt = new GeoPointMsg();
        }

        public BoundingBoxMsg(GeoPointMsg min_pt, GeoPointMsg max_pt)
        {
            this.min_pt = min_pt;
            this.max_pt = max_pt;
        }

        public static BoundingBoxMsg Deserialize(MessageDeserializer deserializer) => new BoundingBoxMsg(deserializer);

        private BoundingBoxMsg(MessageDeserializer deserializer)
        {
            this.min_pt = GeoPointMsg.Deserialize(deserializer);
            this.max_pt = GeoPointMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.min_pt);
            serializer.Write(this.max_pt);
        }

        public override string ToString()
        {
            return "BoundingBoxMsg: " +
            "\nmin_pt: " + min_pt.ToString() +
            "\nmax_pt: " + max_pt.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
