using PlatformerLib.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerLib.Services
{
    public class Gameworld
    {

        public Gameworld()
        {
            GameEntities = new List<GameEntity>();
            GameTimer = new Stopwatch();
        }
        public List<GameEntity> GameEntities { get; set; }

        public Stopwatch GameTimer { get; }

        public void AddEntity(GameEntity entity)
        {
            GameEntities.Add(entity);
        }

        private TimeSpan vorigeGameTick;
        
        public float ElapsedMillisecondsScinceLastTick
        {
            get
            {
                return (float)(GameTimer.Elapsed - vorigeGameTick).TotalMilliseconds;
            }

          
        }

        public void StartTimer()
        {
            GameTimer.Start();
        }


        public void GameTick()
        {
            foreach (var entity in GameEntities)
                entity.GameTick(ElapsedMillisecondsScinceLastTick);

            vorigeGameTick = GameTimer.Elapsed;
        }
    }
}
