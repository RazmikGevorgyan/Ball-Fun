using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FoofleJump
{
    class Bariers : Elements
    {
        public int score;
        public List<Rectangle> bariersList1 =new List<Rectangle>();
        Game game;
        double x { get; set; }
        double y { get; set;}
        Rectangle rec;
        Random rand;

        public Bariers(Game game)
        {
            this.game = game;
            x = (game.mainWindow.Width);
            y = 0;
        }
        public override void Move()
        {
            for(int i=0;i<bariersList1.Count;i++)
            {
                x = Canvas.GetLeft(bariersList1[i]);
                y = Canvas.GetTop(bariersList1[i]);
                x -= 30;
                Canvas.SetLeft(bariersList1[i], x);
                Canvas.SetTop(bariersList1[i], y);
               
            }
            x = Canvas.GetLeft(bariersList1[0]);
            if (x < 0)
            {
                if (bariersList1.Count >=2 && bariersList1.Count <= 8)
                {
                    score += 50;
                    game.mainWindow.label.Content = score.ToString();
                    game.mainWindow.Dasht.Children.Remove(bariersList1[0]);
                    game.mainWindow.Dasht.Children.Remove(bariersList1[1]);
                    bariersList1.RemoveAt(0);
                    bariersList1.RemoveAt(0);
                    this.Nkarel();
                }
            }
            if(x==game.mainWindow.Width/4 || x==game.mainWindow.Width*3/4)
            {
                this.Nkarel();
            }
        }

        public override void Nkarel()
        {
            double height = 0;
            x = game.mainWindow.Width ;
            y = 0;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    rand = new Random();
                    rec = new Rectangle();
                    rec.Width = 20;
                    height=(rec.Height = rand.Next(40, 170));
                    Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));
                    rec.Fill = brush;
                    game.mainWindow.Dasht.Children.Add(rec);
                    bariersList1.Add(rec);
                    Canvas.SetTop(rec, y);
                    Canvas.SetLeft(rec, x);
                 }
                if(i==1)
                {
                    x =(game.mainWindow.Width);
                    y = rand.Next(210,(int)game.mainWindow.Height);
                    rec = new Rectangle();
                    rec.Width = 20;
                    rec.Height = game.mainWindow.Height-(height+30);
                    Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));
                    rec.Fill = brush;
                    game.mainWindow.Dasht.Children.Add(rec);
                    bariersList1.Add(rec);
                    Canvas.SetTop(rec, y);
                    Canvas.SetLeft(rec, x);
                }
            }
        }
        public List<Rectangle> GetBariers()
        {
            return bariersList1;
        }
    }
}
