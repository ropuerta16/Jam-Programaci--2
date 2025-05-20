using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Light : StaticActor
    {
        public Light()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Nuestro/light.png"));
            Position = new Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2);
        }

        public override void Update(float dt)
        {
            base.Update(dt);






        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }
    }
}
