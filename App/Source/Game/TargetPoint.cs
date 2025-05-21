using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class TargetPoint : StaticActor
    {
        public enum TargetType
        {
            Start,
            Intermediate,
            Finish
        }

        public TargetType Type;

        public TargetPoint()
        {
            Layer = ELayer.Entity;
        }
        public override void Update(float dt)
        {
            base.Update(dt);
        }

        public void Init(TargetType type)
        {
            switch (type)
            {
                case TargetType.Start:
                    Sprite = new Sprite(new Texture("Data/Textures/TargetPoint/Scroll.png"));
                    Center();

                    Position = new Vector2f(
                        1f + (GetLocalBounds().Width / 2f),
                        Engine.Get.random.NextFloat(
                            1f + (GetLocalBounds().Height / 2f),
                            Engine.Get.Window.Size.Y - 1f - (GetLocalBounds().Height / 2f)
                        )
                    );
                    break;
                case TargetType.Intermediate:

                    Sprite = new Sprite(new Texture("Data/Textures/TargetPoint/MoneyBag.png"));
                    Center();

                    Position = new Vector2f(
                        Engine.Get.random.NextFloat(
                            GetLocalBounds().Width,
                            Engine.Get.Window.Size.X - GetLocalBounds().Width
                        ),
                        Engine.Get.random.NextFloat(
                            1f + (GetLocalBounds().Height / 2f),
                            Engine.Get.Window.Size.X - 1f - (GetLocalBounds().Height / 2f)
                        )
                    );
                    break;
                case TargetType.Finish:
                    Sprite = new Sprite(new Texture("Data/Textures/TargetPoint/Chest.png"));
                    Center();

                    Position = new Vector2f(
                        Engine.Get.Window.Size.X - 1f - (GetLocalBounds().Width / 2f),
                        Engine.Get.random.NextFloat(
                            1f + (GetLocalBounds().Height / 2f),
                            Engine.Get.Window.Size.Y - 1f - (GetLocalBounds().Height / 2f)
                        )
                    );
                    break;
            }
            Type = type;
        }
    }
}
