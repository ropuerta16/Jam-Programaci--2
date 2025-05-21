using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;

namespace GameJam
{
    public class MyGame : Game
    {
        public Hud HUD { private set; get; }
        public Background Background { get; private set; }
        public Darkness Darkness { get; private set; }
        public Lightbeam Light { get; private set; }
        public List<PowerUp> PowerUps { get; private set; }
        public TargetPoint StartPoint { get; private set; }
        public Beacon StartingBeacon { get; private set; }
        public List<TargetPoint> IntermediatePoints { get; private set; }
        public Character Character { get; private set; }
        public TargetPoint FinishPoint { get; private set; }
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
            Light = Engine.Get.Scene.Create<Lightbeam>();
            Character = Engine.Get.Scene.Create<Character>();

            PowerUps = new List<PowerUp>();
            foreach (int i in Enumerable.Range(0, 5).ToArray()) {
                PowerUps.Add(Engine.Get.Scene.Create<PowerUp>());
            }

            StartPoint = Engine.Get.Scene.Create<TargetPoint>();
            StartPoint.Init(TargetPoint.TargetType.Start);

            StartingBeacon = Engine.Get.Scene.Create<Beacon>();
            StartingBeacon.Position = new Vector2f(StartPoint.Position.X, StartPoint.Position.Y);

            IntermediatePoints = new List<TargetPoint>();
            foreach (int i in Enumerable.Range(0, 4).ToArray())
            {
                TargetPoint intermediatePoint = Engine.Get.Scene.Create<TargetPoint>();
                intermediatePoint.Init(TargetPoint.TargetType.Intermediate);
                IntermediatePoints.Add(intermediatePoint);
            }

            FinishPoint = Engine.Get.Scene.Create<TargetPoint>();
            FinishPoint.Init(TargetPoint.TargetType.Finish);

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

