using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IspitJul22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand;
        DispatcherTimer timer;
        DispatcherTimer oblakTimer;
        List<Talas> itemRemover;
        Povrs povrs;
        bool left = false;
        bool right = false;
        
        public MainWindow()
        {
            InitializeComponent();
            povrs = new Povrs();
            RegisterName("GameCanvas", povrs);

            MyGrid.Children.Add(povrs);
            Grid.SetRow(povrs, 1);
            rand = new Random();
            itemRemover = new List<Talas>();
            timer = new DispatcherTimer();
            oblakTimer = new DispatcherTimer();
            oblakTimer.Interval = TimeSpan.FromMilliseconds(rand.Next(200, 800));
            oblakTimer.Tick += new EventHandler(oblakTimer_Tick);
            oblakTimer.Start();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        void oblakTimer_Tick(object sender, EventArgs e)
        {
            int x = (int)(Canvas.GetLeft(Oblak) + Oblak.Width / 2);
            int y = rand.Next(10, 200);
            EventManager.RainFall(x, y);
            oblakTimer.Interval = TimeSpan.FromMilliseconds(rand.Next(200, 800));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Canvas GameCanvas = FindName("GameCanvas") as Canvas;
            if (left) {
                if(Canvas.GetLeft(Oblak) > 10)
                    Canvas.SetLeft(Oblak, Canvas.GetLeft(Oblak) - 10);
            }
            else if (right) {
                if (Canvas.GetLeft(Oblak) < 480)
                    Canvas.SetLeft(Oblak, Canvas.GetLeft(Oblak) + 10);
            }
            GameCanvas.Children.RemoveRange(0, GameCanvas.Children.Count);
            

            foreach (Talas talas in povrs.talasi)
            {
                if (talas.opacity < 0) {
                    itemRemover.Add(talas);
                    continue;
                }
                
                Ellipse el = new Ellipse()
                {
                    Width = talas.Precnik,
                    Height = talas.Precnik,
                    Stroke = Brushes.Black,
                    StrokeThickness = 3,
                    Opacity = talas.opacity,
                    Fill = Brushes.Transparent
                };
                
                GameCanvas.Children.Add(el);
                Canvas.SetLeft(el, talas.kap.x - talas.Precnik / 2);
                Canvas.SetTop(el, talas.kap.y - talas.Precnik / 2);
            }

            foreach (Talas tls in itemRemover) {
                povrs.talasi.Remove(tls);
            }
            itemRemover.Clear();

            EventManager.TimerTick();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) {
                left = true;
            }
            else if (e.Key == Key.Right) {
                right = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                left = false;
            }
            else if (e.Key == Key.Right)
            {
                right = false;
            }
        }
    }
}
