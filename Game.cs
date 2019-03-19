using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FoofleJump
{
    class Game
    {
        bool crash = false;
        List<Rectangle> TakeList = new List<Rectangle>();
        public MainWindow mainWindow;
        Bariers barier;
        Pixik pixi;
        DispatcherTimer timer;

        public Game(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            barier = new Bariers(this);
            barier.Nkarel();
            pixi = new Pixik(this);
            pixi.Nkarel();
            mainWindow.KeyDown += ControlByKeys;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Gameproces;
            timer.Start();


        }

        private void Gameproces(object sender, EventArgs e)
        {
            pixi.Move();
            pixi.MoveDown();
            barier.Move();
            if(IsCrash()==true || pixi.crash==true)
            {
                this.mainWindow.labelOver.Content = "Game Over";
                timer.Stop();
            }
           
        }

        private void ControlByKeys(object sender, KeyEventArgs e)
        {
            if(e.Key ==Key.Up)
            {
                pixi.keyname = "Up";
            }
        }
        private bool  IsCrash()
        {
            double elispsX = Canvas.GetLeft(pixi.GetPixi());
            double elipseY = Canvas.GetTop(pixi.GetPixi());
            TakeList.AddRange(barier.GetBariers());
            foreach (Rectangle rec in TakeList)
            {
                double x = Canvas.GetLeft(rec);
                double y = Canvas.GetTop(rec);
                if (elispsX < x + rec.Width && elispsX + pixi.GetPixi().Width > x && elipseY < y + rec.Height && elipseY + pixi.GetPixi().Height > y)
                {
                    crash = true;
                }
               
            }
            if (crash == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
