using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace IspitJul22
{
    class Povrs : Canvas
    {
        public List<Talas> talasi { get; set; }
        public Povrs()
        {
            talasi = new List<Talas>();
            EventManager.OnRainFall += new EventManager.FallHandler(EventManager_OnRainFall);
        }

        void EventManager_OnRainFall(int x, int y)
        {
            Kap kap = new Kap(x, y);
            Talas noviTalas = new Talas(kap);
            talasi.Add(noviTalas);
        }



    }
}
