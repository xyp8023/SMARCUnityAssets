using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils = DefaultNamespace.Utils;

namespace VehicleComponents.Sensors
{
    public class Sensor: LinkAttachment
    {
        [Header("Sensor")]
        public float frequency = 10f;
        public bool hasNewData = false;

        private float period => 1.0f/frequency;
        private double lastTime;


        double NowTimeInSeconds()
        {
            // copy from TF2/Clock.cs.
            // Why? Very little chance we'll implement a different thing
            // but i want keep this script free of ros-related things.
            double UnityUnscaledTimeSinceFrameStart = Time.realtimeSinceStartupAsDouble - Time.unscaledTimeAsDouble;
            return Time.timeAsDouble + UnityUnscaledTimeSinceFrameStart * Time.timeScale;
        }

        public virtual bool UpdateSensor(double deltaTime)
        {
            Debug.Log("This sensor needs to override UpdateSensor!");
            return false;
        }

        void FixedUpdate()
        {
            var deltaTime = NowTimeInSeconds() - lastTime;
            if(deltaTime < period) return;
            hasNewData = UpdateSensor(deltaTime);
            lastTime = NowTimeInSeconds();
        }

        void OnDrawGizmosSelected()
        {
            // Draw a semitransparent red cube at the transforms position
            Gizmos.color = new Color(1, 0, 0, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
        }

        void OnDrawGizmos()
        {
            // Draw a semitransparent green cube at the transforms position
            Gizmos.color = new Color(0, 1, 0, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
        }
    }
}