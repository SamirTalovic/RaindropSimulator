using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace IspitJul22
{
    public class Talas
    {
        double promena;
        public double Precnik {get; set;}
        public double opacity {get; set;}
        public Kap kap {get; set;}
        
        public Talas(Kap kap)
        {
            Precnik = 10;
            this.kap = kap;
            opacity = 1;
            promena = kap.q * 2;
            EventManager.OnTimerTick += new EventManager.TimerHandler(EventManager_OnTimerTick);
        }

        void EventManager_OnTimerTick()
        {
            GetNewColor();
            UvecajTalas();
        }

        public void GetNewColor()
        {
            opacity -= 0.1;
        }

        public void UvecajTalas()
        {
            Precnik += promena;
        }

        

    }
}
