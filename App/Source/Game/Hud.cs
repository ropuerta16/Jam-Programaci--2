using SFML.Graphics;
using SFML.System;

namespace GameJam
{
  public class Hud : Actor
  {
        Text t;
        Font f;
        public float health = 100;
        public Hud()
        {
            Layer = ELayer.Hud;
            f = new Font("Data/Fonts/osifont-gpl2fe.ttf");
            t = new Text(health + "/100",f);
            Position = new Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            t.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            health -= 1; 

            t.DisplayedString = string.Format(health + "/100");
        }
  }
}

