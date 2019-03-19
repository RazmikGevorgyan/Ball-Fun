using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FoofleJump
{
    class Pixik:Elements
    {
        public  bool crash = false;
        int x { get; set; }
        int y { get; set; }
        int w { get; set; }
        Ellipse elips;
        Game game;
        public string keyname;

        public Pixik(Game game)
        {
            w = 40;
            this.game = game;
            x= 100;
            y =(int) game.mainWindow.Height / 2;
        }

        public override void Move()
        {
            y =(int) Canvas.GetTop(elips);
            if(keyname=="Up")
            {
                y -= 40;
                if(y>game.mainWindow.Height || y<0)
                {
                    crash = true;
                }
                Canvas.SetTop(elips, y);
            }
            keyname = "";
        }
        public void MoveDown()
        {
            y = (int)Canvas.GetTop(elips);
            y += 10;
            Canvas.SetTop(elips, y);
        }

        public override void Nkarel()
        {
            elips = new Ellipse();
            elips.Height = w;
            elips.Width = w;
            elips.Fill = Brushes.Black;
            game.mainWindow.Dasht.Children.Add(elips);
            Canvas.SetTop(elips, y);
            Canvas.SetLeft(elips, x);

        }
        public Ellipse GetPixi()
        {
            return elips;
        }
    }
}
