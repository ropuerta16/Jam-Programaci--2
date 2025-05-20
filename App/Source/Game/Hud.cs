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
            Layer = ELayer.Hud;
            f = new Font("Data/Fonts/georgia.ttf");
            t = new Text($"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s",f);

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            t.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (MyGame.Get.Light.TimeIncrease > 0f)
            {
                t.DisplayedString = $"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s + {MyGame.Get.Light.TimeIncrease:0.0}s";
                
            } else
            {
                t.DisplayedString = $"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s";
            }
            
        }
  }
}

