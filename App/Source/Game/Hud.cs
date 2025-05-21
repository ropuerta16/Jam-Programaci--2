using SFML.Graphics;
using SFML.System;

namespace GameJam
{
  public class Hud : Actor
  {
        Font f;
        Text t1;
        Text t2;

        public float health;
        public Hud()
        {
            Layer = ELayer.Hud;
            f = new Font("Data/Fonts/georgia.ttf");
            t1 = new Text($"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s",f);
            t2 = new Text($"Current Radius: {MyGame.Get.Light.LightCircle.Radius:0.0}", f);
            t2.Position = new Vector2f(0, t1.GetLocalBounds().Height + 5f);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            t1.Draw(target, states);
            t2.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (MyGame.Get.Light.TimeIncrease > 0f)
            {
                t1.DisplayedString = $"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s + {MyGame.Get.Light.TimeIncrease:0.0}s";
                
            } else
            {
                t1.DisplayedString = $"Light Time: {MyGame.Get.Light.RemainingTime:0.0}s";
            }

            t2.DisplayedString = $"Current Radius: {MyGame.Get.Light.LightCircle.Radius:0.0}";
        }
  }
}

