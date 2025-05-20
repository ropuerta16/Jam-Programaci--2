using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class PowerUp : StaticActor
    {

        public PowerUp()
        {
            Sprite = new Sprite(new Texture("Data/Textures/PowerUp/Potion.png"));
            Random r = new Random();
            float x = r.Next(0, 1024);
            float y = r.Next(0, 768);
            Position = new Vector2f(x, y);

        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

        }
    }
}
