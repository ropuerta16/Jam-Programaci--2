using SFML.Graphics;
using SFML.System;

namespace GameJam
{
  public class GameHUD : Actor
  {
        Font f;
        Text t1;
        Text t2;
        Text t3;

        public float health;
        public GameHUD()
        {
            Layer = ELayer.HUD;
            f = new Font("Data/Fonts/georgia.ttf");
            t1 = new Text($"Light Time: {MyGame.Get.Lightbeam.RemainingTime:0.0}s",f);
            t1.Position = new Vector2f(5f, 5f);
            t2 = new Text($"Current Radius: {MyGame.Get.Lightbeam.LightCircle.Radius:0.0}", f);
            t2.Position = new Vector2f(5f, t1.GetLocalBounds().Height + 5f);
            t3 = new Text($"Current Health: {MyGame.Get.Character.CurrentHealth}", f);
            t3.Position = new Vector2f(Engine.Get.Window.Size.X - t3.GetLocalBounds().Width - 5f, 0f);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            t1.Draw(target, states);
            t2.Draw(target, states);
            t3.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (MyGame.Get.Lightbeam?.TimeIncrease > 0f)
            {
                t1.DisplayedString = $"Light Time: {MyGame.Get.Lightbeam?.RemainingTime:0.0}s + {MyGame.Get.Lightbeam?.TimeIncrease:0.0}s";

            }
            else
            {
                t1.DisplayedString = $"Light Time: {MyGame.Get.Lightbeam?.RemainingTime:0.0}s";
            }

            t2.DisplayedString = $"Current Radius: {MyGame.Get.Lightbeam?.LightCircle.Radius:0.0}";
            t3.DisplayedString = $"Current Health: {MyGame.Get.Character?.CurrentHealth}";
        }
  }
}

