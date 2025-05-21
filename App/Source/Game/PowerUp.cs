using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    public class PowerUp : StaticActor
    {
        public float RemainingTime;
        public PowerUp()
        {
            Layer = ELayer.Entity;
            Sprite = new Sprite(new Texture("Data/Textures/PowerUp/Potion.png"));
            Center();

            Position = new Vector2f(
                Engine.Get.random.NextFloat(GetLocalBounds().Width, Engine.Get.Window.Size.X - GetLocalBounds().Width),
                Engine.Get.random.NextFloat(GetLocalBounds().Height, Engine.Get.Window.Size.Y - GetLocalBounds().Height)
            );

            RemainingTime = Engine.Get.random.Next(5, 10);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && GetGlobalBounds().Contains(Engine.Get.MousePos.X, Engine.Get.MousePos.Y)) {
                RemainingTime -= (dt * 10f);
                MyGame.Get.Light.TimeIncrease += (dt * 10f);
                if (RemainingTime <= 0f) {
                    Destroy();
                }
            }
        }
    }
}
