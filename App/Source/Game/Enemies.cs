using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Enemies : StaticActor
    {
        public Light l;
        public Enemies() 
        {
            Sprite = new Sprite(new Texture("Data/Textures/Enemy/palometa.png"));
            Random random = new Random();
            float x = random.Next(0,1024);
            float y = random.Next(0,764);
            Position = new Vector2f(x,y);
            Speed = 300f;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            Vector2f dist = Engine.Get.MousePos - Position;
            Forward = dist.Normal();
        }
    }
}
