using SFML.Graphics;

namespace GameJam
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;
            Sprite = new Sprite(new Texture("Data/Textures/Background.png"));
        }
        public override void Update(float dt)
        {
        }
    }
}

