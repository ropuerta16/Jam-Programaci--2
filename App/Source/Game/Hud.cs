using SFML.Graphics;
using SFML.System;

namespace GameJam
{
  public class Hud : Actor
  {
        Text t;
        Font f;
        public float health;
        public Hud()
        {
            f = new Font("Data/Fonts/georgia.ttf");
            t = new Text("100/100",f);

        }

        public override void Update(float dt)
        {
            base.Update(dt);

            health -= dt; 

            t.DisplayedString = string.Format(health + "/100");
        }
  }
}

