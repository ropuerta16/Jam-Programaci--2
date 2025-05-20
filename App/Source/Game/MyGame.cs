using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    public class MyGame : Game
    {
        public Hud HUD { private set; get; }
        public Background Background { get; private set; }
        public Darkness Darkness { get; private set; }
        public Light Light { get; private set; }
        private static MyGame instance;
        public static MyGame Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyGame();
                }

                return instance;
            }
        }
        private MyGame()
        {
        }
        public void Init()
        {
            Background = Engine.Get.Scene.Create<Background>();
            Darkness = Engine.Get.Scene.Create<Darkness>();
            Light = Engine.Get.Scene.Create<Light>();

            Engine.Get.Scene.Create<PowerUp>();
            Engine.Get.Scene.Create<PowerUp>();
            Engine.Get.Scene.Create<PowerUp>();
            Engine.Get.Scene.Create<PowerUp>();

            HUD = Engine.Get.Scene.Create<Hud>();
        }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {

        }
    }
}

