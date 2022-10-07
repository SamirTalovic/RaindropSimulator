using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IspitJul22
{
    public class EventManager
    {
        public delegate void TimerHandler();
        public static event TimerHandler OnTimerTick;

        public delegate void FallHandler(int x, int y);
        public static event FallHandler OnRainFall;

        public static void RainFall(int x, int y) {
            if(OnRainFall != null) {
                OnRainFall(x, y);
            }
        }

        public static void TimerTick() {
            if (OnTimerTick != null) {
                OnTimerTick();
            }
        }

    }
}
