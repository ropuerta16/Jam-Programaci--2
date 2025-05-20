using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Light : StaticActor
    {
        CircleShape cs;
        public Light()
        {
            cs = new CircleShape(20f);
            cs.FillColor = Color.White;
            Layer = ELayer.Front;
            cs.Origin = new Vector2f(GetLocalBounds().Width / 2 ,GetLocalBounds().Height / 2 );
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            Position = new Vector2f(Engine.Get.MousePos.X, Engine.Get.MousePos.Y);
            cs.Position = new Vector2f(Position.X, Position.Y);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            cs.Draw(target, states);
        }
    }
}
