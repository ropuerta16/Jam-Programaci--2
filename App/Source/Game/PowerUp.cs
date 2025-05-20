using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameJam
{
    internal class PowerUp:StaticActor
    {
        public PowerUp()
        {
            Sprite = new Sprite(new Texture("Data/texture/light.png"));

        }
    }
}
