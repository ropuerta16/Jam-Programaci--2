using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Intro : StaticActor
    {
        private readonly string title = "LIGHTBRINGER";
        private readonly string description = "Consigue que el pequeño demonio llegue al final del recorrido con vida. \n Debes alumbrarlo con tu luz para que no se haga daño, pero ten cuidado,\n tu liz ira diminuyendo con el tiempo.\n Busca Powerups en el mapa para no apagar tu luz mientras matas polillas que intentaran robartela. \n\nLas polillas mueren al hacerles clic con el ratón.\nLa luz seguira tu cursor automaticamente por el mapa.";
        private readonly string subtitle = "PRESS ENTER TO START";

        private Font font, titleFont;
        private Text titleText, descriptionText, subtitleText;
        private Color titleColor = Color.Blue;
        private Color descriptionColor = Color.White;
        private Color subtitleColor = Color.Cyan;
        private Sprite introImage;
        public Intro()
        {
            titleFont = new Font("Data/Fonts/Scratchy Lemon.ttf");
            font = new Font("Data/Fonts/osifont-gpl2fe.ttf");

            titleText = new Text(title, titleFont, 80);
            titleText.FillColor = titleColor;

            descriptionText = new Text(description, font, 28);
            descriptionText.FillColor = descriptionColor;

            subtitleText = new Text(subtitle, titleFont, 40);
            subtitleText.FillColor = subtitleColor;

            introImage = new Sprite(new Texture("Data/Textures/PowerUp/People01.png"));
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var window = Engine.Get.Window;
            var size = window.Size;

            var titleBounds = titleText.GetLocalBounds();
            titleText.Position = new Vector2f((size.X - titleBounds.Width) / 2f, 30);

            var descBounds = descriptionText.GetLocalBounds();
            descriptionText.Position = new Vector2f((size.X - descBounds.Width) / 2f, (size.Y - descBounds.Height) / 2f);

            var subtitleBounds = subtitleText.GetLocalBounds();
            subtitleText.Position = new Vector2f((size.X - subtitleBounds.Width) / 2f, size.Y - subtitleBounds.Height - 40);

            target.Draw(titleText, states);
            target.Draw(descriptionText, states);
            target.Draw(subtitleText, states);

            var spriteBounds = introImage.GetLocalBounds();
            introImage.Position = new Vector2f((size.X + spriteBounds.Width) / 2f, 60);
            target.Draw(introImage, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            /*
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Space))
            {
                //canviar d'estat
            }*/
        }
    }
}
