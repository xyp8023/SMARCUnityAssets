//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Sam
{
    [Serializable]
    public class PercentStampedMsg : Message
    {
        public const string k_RosMessageName = "sam_msgs/PercentStamped";
        public override string RosMessageName => k_RosMessageName;

        public float value;
        public Std.HeaderMsg header;

        public PercentStampedMsg()
        {
            this.value = 0.0f;
            this.header = new Std.HeaderMsg();
        }

        public PercentStampedMsg(float value, Std.HeaderMsg header)
        {
            this.value = value;
            this.header = header;
        }

        public static PercentStampedMsg Deserialize(MessageDeserializer deserializer) => new PercentStampedMsg(deserializer);

        private PercentStampedMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.value);
            this.header = Std.HeaderMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.value);
            serializer.Write(this.header);
        }

        public override string ToString()
        {
            return "PercentStampedMsg: " +
            "\nvalue: " + value.ToString() +
            "\nheader: " + header.ToString();
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
