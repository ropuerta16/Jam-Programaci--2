using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Intro : StaticActor
    {
        private readonly string title = "LIGHTBRINGER";
        private readonly string mision = "Consigue que el pequeño demonio llegue al final del recorrido con vida.";
        private readonly string description = "\n\nDebes alumbrarlo con tu luz para que no se haga daño, pero ten cuidado,\n  tu luz ira diminuyendo con el tiempo.\nBusca Powerups en el mapa para no apagar tu luz mientras matas polillas\n  que intentaran robartela.\n\n- La luz seguira tu cursor automaticamente por el mapa.\n- Para absorber la PowerUp deja presionado encima de la poción.\n- Las polillas mueren al hacerles clic con el ratón.";
        private readonly string subtitle = "PRESS SPACE TO START";

        private Font font, titleFont;
        private Text titleText, descriptionText, misionText, subtitleText;
        private Color titleColor = Color.Blue;
        private Color misionColor = Color.Cyan;
        private Color descriptionColor = Color.White;
        private Color subtitleColor = Color.Blue;
        private Sprite introImage;

        private Color backgroundColor = new Color(30, 30, 60);
        public Intro()
        {
            titleFont = new Font("Data/Fonts/Scratchy Lemon.ttf");
            font = new Font("Data/Fonts/osifont-lgpl3fe.ttf");
                        
            titleText = new Text(title, titleFont, 100);
            titleText.FillColor = titleColor;

            misionText = new Text(mision, font, 30);
            misionText.FillColor = misionColor;

            descriptionText = new Text(description, font, 28);
            descriptionText.FillColor = descriptionColor;                                   

            subtitleText = new Text(subtitle, titleFont, 40);
            subtitleText.FillColor = subtitleColor;

            introImage = new Sprite(new Texture("Data/Textures/Player/Character.png"));
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var window = Engine.Get.Window;
            var size = window.Size;

            var titleBounds = titleText.GetLocalBounds();
            titleText.Position = new Vector2f((size.X - titleBounds.Width) / 2f, 30);

            var misionBounds = misionText.GetLocalBounds();
            misionText.Position = new Vector2f((size.X - misionBounds.Width) / 2f, 200);

            var descBounds = descriptionText.GetLocalBounds();
            descriptionText.Position = new Vector2f((size.X - descBounds.Width) / 2f, (size.Y - descBounds.Height) / 2f);

            var subtitleBounds = subtitleText.GetLocalBounds();
            subtitleText.Position = new Vector2f((size.X - subtitleBounds.Width) / 2f, size.Y - subtitleBounds.Height - 40);

            RectangleShape backgroundRect = new RectangleShape(new Vector2f(size.X, size.Y));
            backgroundRect.FillColor = backgroundColor;
            target.Draw(backgroundRect, states);

            target.Draw(titleText, states);
            target.Draw(misionText, states);
            target.Draw(descriptionText, states);
            target.Draw(subtitleText, states);

            var imageBounds = introImage.GetLocalBounds();
            introImage.Position = new Vector2f((size.X + 450) / 2f, size.Y - imageBounds.Height - 40);
            target.Draw(introImage, states);
        }        
    }
}
