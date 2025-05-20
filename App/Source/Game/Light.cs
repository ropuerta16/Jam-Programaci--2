using Candle;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Light : StaticActor
    {
        public RadialLight LightSource;
        public CircleShape LightCircle;

        public float RemainingTime;
        public float TimeIncrease;
        private const float RadiusRatio = 2.5f;

        public Light()
        {
            LightSource = new RadialLight();
            LightCircle = new CircleShape();
            LightCircle.FillColor = Color.White;
            LightSource.Range = LightCircle.Radius;

            Center();
            Speed = 100f;

            Position = new Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2);

            RemainingTime = 40.0f;
            TimeIncrease = 0f;
            LightCircle.Radius = (RemainingTime * RadiusRatio);
            LightSource.Range = LightCircle.Radius;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (TimeIncrease > 0f)
            {
                TimeIncrease -= (dt * 2f);
                RemainingTime += (dt * 2f);
            } else
            {
                RemainingTime -= dt;
            }
                
            LightCircle.Radius = (RemainingTime * RadiusRatio);
            LightSource.Range = LightCircle.Radius;

            LightSource.Position = new Vector2f(Position.X, Position.Y);
            LightCircle.Position = new Vector2f(Position.X, Position.Y);
            Forward = (Engine.Get.MousePos - Position).Normal();
            MyGame.Get.Darkness.Lights.Add(LightSource);
        }
    }
}
