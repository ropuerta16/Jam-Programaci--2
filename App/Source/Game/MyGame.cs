using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace GameJam
{
    public class MyGame : Game
    {
        private string state = "intro";
        private string previousState = null;

        private SoundManager soundManager;
        private Sound introAudio;
        private Sound playingAudio;
        private Sound loseAudio;
        private Sound winAudio;

        public Hud hud { private set; get; }
        public Background background { get; private set; }
        public Light light { private set; get; }
        public Enemies enemies { private set; get; }
        public Intro intro { private set; get; }
        public GameOver gameOver { private set; get; }
        public GameWin gameWin { private set; get; }

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
            if (soundManager == null)
                soundManager = new SoundManager();
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
                        introAudio = soundManager.PlaySound("IntroAudio", 30.0f, true);
                        break;
                    case "game":                        
                        background = Engine.Get.Scene.Create<Background>();
                        hud = Engine.Get.Scene.Create<Hud>();
                        light = Engine.Get.Scene.Create<Light>();
                        enemies = Engine.Get.Scene.Create<Enemies>();
                        playingAudio = soundManager.PlaySound("PlayingAudio", 30.0f, true);
                        state = "playing"; 
                        break;
                    case "playing":                        
                        break;
                    case "gameOver":
                        gameOver = Engine.Get.Scene.Create<GameOver>();
                        loseAudio = soundManager.PlaySound("LoseAudio", 100.0f, false);
                        break;
                    case "gameWin":
                        gameWin = Engine.Get.Scene.Create<GameWin>();
                        winAudio = soundManager.PlaySound("WinAudio", 100.0f, false);
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
                case "game":
                    break;
                case "playing":
                    if (Keyboard.IsKeyPressed(Keyboard.Key.O))
                    {
                        state = "gameOver";
                    } 
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                    {
                        state = "gameWin";
                    }
                        break;
                case "gameOver":
                    if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                    {
                        state = "game";
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    {
                        Environment.Exit(0);
                    }
                    break;
                case "gameWin":
                    if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                    {
                        state = "game";
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    {
                        Environment.Exit(0);
                    }
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
                    if (introAudio != null)
                    {
                        soundManager.RemoveSound(introAudio);
                        introAudio = null;
                    }
                    break;
                case "game":
                    break;
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
                    if (playingAudio != null)
                    {
                        soundManager.RemoveSound(playingAudio);
                        playingAudio = null;
                    }
                    break;
                case "gameOver":
                    if (gameOver != null)
                    {
                        Engine.Get.Scene.Destroy(gameOver);
                        gameOver = null;
                    }
                    if (loseAudio != null)
                    {
                        soundManager.RemoveSound(loseAudio);
                        loseAudio = null;
                    }
                    break;
                case "gameWin":
                    if (gameWin != null)
                    {
                        Engine.Get.Scene.Destroy(gameWin);
                        gameWin = null;
                    }
                    if (winAudio != null)
                    {
                        soundManager.RemoveSound(winAudio);
                        winAudio = null;
                    }
                    break;
            }
        }
    }
}

