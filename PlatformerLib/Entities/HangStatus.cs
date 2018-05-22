using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerLib.Services;

namespace PlatformerLib.Entities
{
    public class HangStatus
    {
        public enum hangStatus
        {
            Geen, Paal, Touw, Hoofd, Lichaam, LinkerHand, RechterHand, LinkerBeen, RechterBeen
        }
    }
}
