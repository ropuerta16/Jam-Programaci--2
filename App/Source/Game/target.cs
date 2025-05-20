using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    internal class Target : StaticActor
    {
        enum Type
        {
            Start,
            Intermediate,
            Finish
        }
        public Target(float minX, float maxX)
        {
            Sprite = new Sprite(new Texture("Data/Textures/Points/pergamino.png"));
            Type = Type.Start;
            
            float x = random.Next(0, 1024);
            float y = random.Next(0, 764);
            Position = new Vector2f(x, y);
            Speed = 300f;


        }
    }
}
