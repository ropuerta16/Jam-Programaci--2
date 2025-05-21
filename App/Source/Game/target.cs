using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    public class Target : StaticActor
    {
        Random random = new Random();
        public int minX; public int maxX;
        public int minY = 0; public int maxY=764;
        int moneybagCounter = 0;
        public enum Type 
        {
            Start,
            Intermediate,
            Finish
        }
        public Type type;
        
        public Target()
        {
            Layer = ELayer.Entity;
            type = Type.Start;
        }
        public override void Update(float dt)
        {
            base.Update(dt);

            if (type == Type.Intermediate && GetGlobalBounds().Intersects(MyGame.Get.character.GetGlobalBounds()))
            {
                moneybagCounter++;
            }
            if (type == Type.Finish && GetGlobalBounds().Intersects(MyGame.Get.character.GetGlobalBounds()))
            {
                //win condition
            }
        }
        
        public void Spawner(int minX, int maxX, Type type)
        {
            switch (type)
            {
                case Type.Start:
                    Sprite = new Sprite(new Texture("Data/Textures/Points/pergamino.png"));

                    float x = random.Next(minX, maxX);
                    float y = random.Next(minY, maxY);
                    Position = new Vector2f(x, y);
                    Sprite.Position = new Vector2f(x, y);

                    break;

                case Type.Intermediate:
                    
                    Sprite = new Sprite(new Texture("Data/Textures/Points/moneybag.png"));

                    while (moneybagCounter < 4)
                    {
                        x = random.Next(minX, maxX);
                        y = random.Next(minY, maxY);
                        Position = new Vector2f(x, y);
                        Sprite.Position = new Vector2f(x, y);
                        
                    }
                    type = Type.Finish;
                    break;

                case Type.Finish:
                    Sprite = new Sprite(new Texture("Data/Textures/Points/chest.png"));

                    x = random.Next(minX, maxX);
                    y = random.Next(minY, maxY);
                    Position = new Vector2f(x, y);
                    
                    break;
            }
        }
    }
}
