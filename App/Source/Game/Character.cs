using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
namespace GameJam
{
    public class Character : StaticActor
    {
        TargetPoint currentTarget;
        public Character()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Player/Character.png"));
            Random random = new Random();
            float x = random.Next(0, 1024);
            float y = random.Next(0, 764);
            Position = new Vector2f(x, y);
            Speed = 30f;
            currentTarget = MyGame.Get.IntermediatePoints[random.Next(0, MyGame.Get.IntermediatePoints.Count)];

        }

        public override void Update(float dt)
        {
            base.Update(dt);

            
        }
        public void Draw()
        {
            
        }
        


    }
}
