using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;


namespace PlatformerLib.Entities
{
     public class Player1 : GameEntity
    {

        public float Radius { get; set; }
        public override void Draw(WriteableBitmap surface)
        {
            
            base.Draw(surface);
        }

    }
}
