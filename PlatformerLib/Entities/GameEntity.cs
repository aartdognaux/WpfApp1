using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PlatformerLib.Entities
{
    public abstract class GameEntity
    {

        // Positie van huidig game element
        public Vector2 Plaats { get; set; }

        //beweging van huidig game element

        public Vector2 Beweging { get; set; }

        //Game Logic 
        public virtual void GameTick(float milliSecondsElapsed)
        {

        }

        

        public virtual void Draw(WriteableBitmap surface)
        {
          
        }



    }
}
