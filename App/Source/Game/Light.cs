using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Light : StaticActor
    {
        public Light()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Nuestro/light.png"));
            Position = new Vector2f(GetGlobalBounds().Width / 2, GetGlobalBounds().Height / 2);
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
