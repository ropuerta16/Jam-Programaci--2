using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameJam
{
    public class InputHandler : Actor
    {
        public float PulseRemainingTime;
        public const float PulseMaxTime = 2f;
        public float PulseCurrentCooldown;
        public const float PulseMaxCooldown = 12f;
        public const float PulseRadiusRatio = 10f;

        CircleShape PulseCircle;
        Vector2f PulsePosition;
        public InputHandler()
        {
            Layer = ELayer.Front;
            Engine.Get.Window.MouseButtonPressed += OnClick;
            Engine.Get.Window.KeyPressed += OnKeyPressed;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            if (PulseRemainingTime > 0) PulseCircle.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (PulseRemainingTime > 0) {
                PulseRemainingTime -= dt;
                PulseCircle.Radius = PulseRemainingTime * PulseRadiusRatio;
                PulseCircle.Origin = new Vector2f(PulseCircle.GetLocalBounds().Width / 2f, PulseCircle.GetLocalBounds().Height / 2f);
                PulseCircle.Position = new Vector2f(PulsePosition.X, PulsePosition.Y);
            }
            else { PulseRemainingTime = 0; PulseCircle = null; }

            if (PulseCurrentCooldown > 0) PulseCurrentCooldown -= dt;
            else PulseCurrentCooldown = 0;
        }

        public void OnClick(object sender, MouseButtonEventArgs args)
        {
            //Hitting Moths
            if (args.Button == Mouse.Button.Left && Engine.Get.Scene.GetAll<Moth>().Count > 0) {
                List<Moth> moths = Engine.Get.Scene.GetAll<Moth>()
                    .Where(m => (m.Position - Engine.Get.MousePos).Size() <= m.CircleCollider.Radius)
                    .ToList();

                if (moths.Count > 0) moths.First().Hit();
            }
        }

        public void OnKeyPressed(object sender, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.Space && PulseCurrentCooldown <= 0f)
            {
                PulseCurrentCooldown = PulseMaxCooldown;
                PulseRemainingTime = PulseMaxTime;

                PulseCircle = new CircleShape(PulseMaxTime * PulseRadiusRatio);
                PulseCircle.Origin = new Vector2f(PulseCircle.GetLocalBounds().Width / 2f, PulseCircle.GetLocalBounds().Height / 2f);
                PulseCircle.FillColor = new Color(0, 255, 0, 100);

                List<PowerUp> powerUps = Engine.Get.Scene.GetAll<PowerUp>();
                PowerUp fartherPowerUps = Engine.Get.Scene.GetAll<PowerUp>()
                    .OrderBy(p => (Engine.Get.MousePos - p.Position).Size())
                    .Reverse()
                    .ToList()
                    .First();

                PulsePosition = new Vector2f(fartherPowerUps.Position.X, fartherPowerUps.Position.Y);
                PulseCircle.Position = new Vector2f(PulsePosition.X, PulsePosition.Y);
            }
        }
    }
}
