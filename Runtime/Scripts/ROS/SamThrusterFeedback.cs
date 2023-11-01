using RosMessageTypes.Smarc;
using Unity.Robotics.Core; // Clock

namespace DefaultNamespace
{
    public class SamThrusterFeedback : Sensor<ThrusterFeedbackMsg>
    {
        public int thrusterNum;
        SAMForceModel model;
        double rpm;
        void Start()
        {
            model = robotMotionModel.GetComponent<SAMForceModel>();
        }

        public override bool UpdateSensor(double deltaTime)
        {
            rpm = thrusterNum==1 ? model.rpm1 : model.rpm2;
            ros_msg.rpm.rpm = (int)rpm;
            ros_msg.header.stamp = new TimeStamp(Clock.time);
            ros_msg.header.frame_id = robotLinkName; //from sensor
            return true;
        }
    }
}