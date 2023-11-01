//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Sam
{
    [Serializable]
    public class ConsumedChargeFeedbackMsg : Message
    {
        public const string k_RosMessageName = "sam_msgs/ConsumedChargeFeedback";
        public override string RosMessageName => k_RosMessageName;

        // 
        //  Consumed charge for all power rails
        // 
        public Std.HeaderMsg header;
        // 
        //  Consumed charge mAh
        // 
        public float main;
        public float esc1;
        public float esc2;
        public float esc3;
        public float v20;
        public float v12;
        public float v7;
        public float v5;
        public float v33;

        public ConsumedChargeFeedbackMsg()
        {
            this.header = new Std.HeaderMsg();
            this.main = 0.0f;
            this.esc1 = 0.0f;
            this.esc2 = 0.0f;
            this.esc3 = 0.0f;
            this.v20 = 0.0f;
            this.v12 = 0.0f;
            this.v7 = 0.0f;
            this.v5 = 0.0f;
            this.v33 = 0.0f;
        }

        public ConsumedChargeFeedbackMsg(Std.HeaderMsg header, float main, float esc1, float esc2, float esc3, float v20, float v12, float v7, float v5, float v33)
        {
            this.header = header;
            this.main = main;
            this.esc1 = esc1;
            this.esc2 = esc2;
            this.esc3 = esc3;
            this.v20 = v20;
            this.v12 = v12;
            this.v7 = v7;
            this.v5 = v5;
            this.v33 = v33;
        }

        public static ConsumedChargeFeedbackMsg Deserialize(MessageDeserializer deserializer) => new ConsumedChargeFeedbackMsg(deserializer);

        private ConsumedChargeFeedbackMsg(MessageDeserializer deserializer)
        {
            this.header = Std.HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.main);
            deserializer.Read(out this.esc1);
            deserializer.Read(out this.esc2);
            deserializer.Read(out this.esc3);
            deserializer.Read(out this.v20);
            deserializer.Read(out this.v12);
            deserializer.Read(out this.v7);
            deserializer.Read(out this.v5);
            deserializer.Read(out this.v33);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.main);
            serializer.Write(this.esc1);
            serializer.Write(this.esc2);
            serializer.Write(this.esc3);
            serializer.Write(this.v20);
            serializer.Write(this.v12);
            serializer.Write(this.v7);
            serializer.Write(this.v5);
            serializer.Write(this.v33);
        }

        public override string ToString()
        {
            return "ConsumedChargeFeedbackMsg: " +
            "\nheader: " + header.ToString() +
            "\nmain: " + main.ToString() +
            "\nesc1: " + esc1.ToString() +
            "\nesc2: " + esc2.ToString() +
            "\nesc3: " + esc3.ToString() +
            "\nv20: " + v20.ToString() +
            "\nv12: " + v12.ToString() +
            "\nv7: " + v7.ToString() +
            "\nv5: " + v5.ToString() +
            "\nv33: " + v33.ToString();
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
