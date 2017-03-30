using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class DelayCheck
    {
        public float Delay { set; get; }

        private float lastFired = float.MinValue;
        public float LastFired { get { return lastFired; } }

        public DelayCheck(float delay, float startTime = 0)
        {
            Delay = delay;
            lastFired = startTime;
        }

        public bool Check(float current)
        {
            if (current > lastFired + Delay)
            {
                lastFired = current;
                return true;
            }

            return false;
        }
    }
}