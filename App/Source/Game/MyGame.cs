using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background background { get; private set; }
        public Light light { private set; get; }
        public Enemies enemies { private set; get; }



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
            background = Engine.Get.Scene.Create<Background>();
            hud = Engine.Get.Scene.Create<Hud>();
            light = Engine.Get.Scene.Create<Light>();
            enemies = Engine.Get.Scene.Create<Enemies>();
        }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {

        }
    }
}

