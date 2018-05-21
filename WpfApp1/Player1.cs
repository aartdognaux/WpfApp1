using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerLib.Entities;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WpfApp1
{
    public class Player1 : GameEntity
    {

        public float Radius { get; set; }

        public override void GameTick(float millisecondsElapsed)
        {
            Plaats = Plaats + Beweging * millisecondsElapsed / 1000f;
        }

        public override void Draw(WriteableBitmap surface)
        {
            surface.FillEllipse((int)Plaats.X, (int)Plaats.Y, (int)(Plaats.X + Radius), (int)(Plaats.Y + Radius), Colors.Red);
            base.Draw(surface);
        }

    }
}
