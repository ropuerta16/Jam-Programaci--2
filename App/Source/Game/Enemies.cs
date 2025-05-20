using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    public class Enemies : StaticActor
    {
        public float angle;
        int vidasCounter = 0;
        float coolDown = 0.25f;
        public Enemies()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Enemy/palometa.png"));
            Random random = new Random();
            float x = random.Next(0, 1024);
            float y = random.Next(0, 764);
            Position = new Vector2f(0, 0);
            Speed = 1f;
            angle = 0f;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            angle += 0.25f * dt;

            float dist = 200f;

            Vector2f d = new Vector2f
            (
                MyGame.Get.light.Position.X + (dist * (float)Math.Cos(angle / MathUtil.DEG2RAD)),
                MyGame.Get.light.Position.Y + (dist * (float)Math.Sin(angle / MathUtil.DEG2RAD))
            );


            Forward = d - Position;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) && coolDown <= 0f && GetGlobalBounds().Contains(Engine.Get.MousePos.X, Engine.Get.MousePos.Y))
            {
                vidasCounter++;
                coolDown = 0.25f;
            }
            if (vidasCounter >= 3)
            {
                Destroy();
            }

        }
    }
}

