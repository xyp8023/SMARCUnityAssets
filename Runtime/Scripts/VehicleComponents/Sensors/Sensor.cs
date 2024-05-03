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

        public virtual void UpdateSensor(double deltaTime)
        {
            Debug.Log("This sensor needs to override UpdateSensor!");
        }

        void FixedUpdate()
        {
            var deltaTime = NowTimeInSeconds() - lastTime;
            if(deltaTime < period) return;
            UpdateSensor(deltaTime);
            lastTime = NowTimeInSeconds();
        }
    }
}