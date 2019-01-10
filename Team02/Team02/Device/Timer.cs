using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Device
{
    public class Timer
    {
        private int limitTime;
        private int currentTime;

        public int LimitTime { get => limitTime / 60; set => limitTime = value * 60; }
        public int CurrentTime { get => currentTime / 60; }
        public float Rate { get => (float)currentTime / (float)limitTime; }
        public bool IsTime { get => currentTime >= LimitTime; }

        public void Start()
        {
            currentTime = 0;
        }

        public void Update()
        {
            currentTime += 1;
        }
    }
}
