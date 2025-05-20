using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    public class MyGame : Game
    {
        private string state = "intro";
        private string previousState = null;

        public Hud hud { private set; get; }
        public Background background { get; private set; }
        public Light light { private set; get; }
        public Enemies enemies { private set; get; }
        public Intro intro { private set; get; }

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
            state = "intro";                               
        }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {
            if (state != previousState)
            {
                CleanupState(previousState);

                switch (state)
                {
                    case "intro":
                        intro = Engine.Get.Scene.Create<Intro>();
                        break;
                    case "game":
                        background = Engine.Get.Scene.Create<Background>();
                        hud = Engine.Get.Scene.Create<Hud>();
                        light = Engine.Get.Scene.Create<Light>();
                        enemies = Engine.Get.Scene.Create<Enemies>();
                        state = "playing"; 
                        break;
                    case "playing":
                        break;
                    case "gameOver":
                        break;
                }

                previousState = state;
            }

            switch (state)
            {
                case "intro":
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                    {
                        state = "game";
                    }
                    break;
                case "playing":
                    break;
                case "gameOver":
                    break;
            }
        }

        private void CleanupState(string oldState)
        {
            switch (oldState)
            {
                case "intro":
                    if (intro != null)
                    {
                        Engine.Get.Scene.Destroy(intro);
                        intro = null;
                    }
                    break;
                case "game":
                case "playing":
                    if (background != null)
                    {
                        Engine.Get.Scene.Destroy(background);
                        background = null;
                    }
                    if (hud != null)
                    {
                        Engine.Get.Scene.Destroy(hud);
                        hud = null;
                    }
                    if (light != null)
                    {
                        Engine.Get.Scene.Destroy(light);
                        light = null;
                    }
                    if (enemies != null)
                    {
                        Engine.Get.Scene.Destroy(enemies);
                        enemies = null;
                    }
                    break;
                case "gameOver":
                    break;
            }
        }
    }
}

