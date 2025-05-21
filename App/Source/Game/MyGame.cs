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
        public Character character { private set; get; }

        
        

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
            character = Engine.Get.Scene.Create<Character>();

            Target target1 = Engine.Get.Scene.Create<Target>();
            target1.minX = 0; target1.maxX = 21;
            target1.type= Target.Type.Start;

            for (int i = 0; i < 4; i++)
            {
                Target target2 = Engine.Get.Scene.Create<Target>();
                target2.minX = 21; target2.maxX = 1004;
            }

            Target target3 = Engine.Get.Scene.Create<Target>();
            target3.minX = 1004; target3.maxX = 1025;
        }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {

        }
    }
}

