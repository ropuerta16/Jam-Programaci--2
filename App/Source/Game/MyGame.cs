using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background background { get; private set; }

        public Intro intro { get; private set; }
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
            intro = Engine.Get.Scene.Create<Intro>();
    
    }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {

        }
    }
}

