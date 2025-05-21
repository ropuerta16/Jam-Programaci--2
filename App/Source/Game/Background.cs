using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;
            Sprite = new Sprite(new Texture("Data/Textures/Background/Background.png"));
        }
        public override void Update(float dt)
        {
        }
    }
}

