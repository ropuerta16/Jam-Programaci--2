using SFML.Window;
using System.Collections.Generic;
using System.Linq;

namespace GameJam
{
    public class ClickHandler : Actor
    {
        public ClickHandler()
        {
            Engine.Get.Window.MouseButtonPressed += OnClick;
        }

        public void OnClick(object sender, MouseButtonEventArgs args)
        {
            //Hitting Moths
            if (args.Button == Mouse.Button.Left && Engine.Get.Scene.GetAll<Moth>().Count > 0) {
                List<Moth> moths = Engine.Get.Scene.GetAll<Moth>()
                    .Where(m => (m.Position - Engine.Get.MousePos).Size() <= m.CircleCollider.Radius)
                    .ToList();

                if (moths.Count > 0) moths.First().Hit();
            }
        }
    }
}
