using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Device
{
    public class Timer
    {
        private float limitTime;
        private float currentTime;

        public float LimitTime { get => limitTime / 60; set => limitTime = value * 60; }
        public float CurrentTime { get => currentTime; }
        public float Rate { get => 1 - currentTime / limitTime; }
        public bool IsTime { get => currentTime <= 0; }

        public Timer(float limitTime)
        {
            this.limitTime = limitTime * 60;
            currentTime = this.limitTime;
        }

        public void Start()
        {
            currentTime = limitTime;
        }

        public void Update()
        {
            currentTime = Math.Max(currentTime - 1f, 0.0f);
        }
    }
}
