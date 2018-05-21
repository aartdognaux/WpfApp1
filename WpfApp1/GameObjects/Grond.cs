using PlatformerLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.GameObjects
{
    public class Grond : GameEntity
    {

        public override void GameTick(float millisecondsElapsed)
        {
            Plaats = Plaats;
        }

        public override void Draw(WriteableBitmap surface)
        {
            surface.DrawRectangle(0, 530, 1000, 600, Colors.Red);
            base.Draw(surface);
        }

    }
}
