using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class Intro : StaticActor
    {
        private readonly string title = "LIGHTBRINGER";
        private readonly string mision = "Consigue que el pequeño demonio llegue al final del recorrido con vida.";
        private readonly string description = "\n\nDebes alumbrarlo con tu luz para que no se haga daño, pero ten cuidado,\n  tu luz irá disminuyendo con el tiempo.\nBusca pociones en el mapa para no apagar tu luz mientras matas polillas\n  que intentan robártela.";
        private readonly string howPlay = "- La luz seguirá tu cursor automáticamente por el mapa.\n- Para absorber la poción, deja presionado encima de ella.\n- Las polillas mueren al hacer clic con el ratón sobre estas.";
        private readonly string subtitle = "EMPEZAR";

        private Font font, titleFont;
        private Text titleText, descriptionText, misionText, howPlayText, subtitleText;

        private Color titleColor = Color.Black;
        private Color misionColor = Color.Blue;
        private Color descriptionColor = Color.Black;
        private Color subtitleColor = Color.Blue;
        private Color howPlayColor = Color.White;
        
        private Sprite introImage;

        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public Intro()
        {
            titleFont = new Font("Data/Fonts/Scratchy Lemon.ttf");
            font = new Font("Data/Fonts/osifont-lgpl3fe.ttf");
                        
            titleText = new Text(title, titleFont, 160);
            titleText.FillColor = titleColor;

            misionText = new Text(mision, font, 40);
            misionText.FillColor = misionColor;

            descriptionText = new Text(description, font, 33);
            descriptionText.FillColor = descriptionColor;                                   

            subtitleText = new Text(subtitle, titleFont, 70);
            subtitleText.FillColor = subtitleColor;

            howPlayText = new Text(howPlay, font, 28);
            howPlayText.FillColor = howPlayColor;

            introImage = new Sprite(new Texture("Data/Textures/Player/Character.png"));

            backgroundTexture = new Texture("Data/Textures/Background/MenusFondo.jpg");
            backgroundSprite = new Sprite(backgroundTexture);

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var window = Engine.Get.Window;
            var size = window.Size;
                        
            var titleBounds = titleText.GetLocalBounds();
            titleText.Position = new Vector2f((size.X - titleBounds.Width) / 2f, 35);

            var misionBounds = misionText.GetLocalBounds();
            misionText.Position = new Vector2f((size.X - misionBounds.Width) / 2f, 250);

            var descBounds = descriptionText.GetLocalBounds();
            descriptionText.Position = new Vector2f((size.X - descBounds.Width) / 2f, ((size.Y - descBounds.Height) / 2f) - 80);

            var subtitleBounds = subtitleText.GetLocalBounds();
            subtitleText.Position = new Vector2f((size.X - subtitleBounds.Width) / 2f,((size.Y - subtitleBounds.Height) / 2f) + 118);

            var howPlayBounds = howPlayText.GetLocalBounds();
            howPlayText.Position = new Vector2f((size.X - howPlayBounds.Width) / 2f, size.Y - howPlayBounds.Height - 50);

            backgroundSprite.Scale = new Vector2f((float)size.X / backgroundTexture.Size.X,(float)size.Y / backgroundTexture.Size.Y);
            backgroundSprite.Position = new Vector2f(0, 0);

            var introImageBounds = introImage.GetLocalBounds();
            introImage.Position = new Vector2f((size.X - introImageBounds.Width) / 2f, ((size.Y - introImageBounds.Height) / 2f) + 208);

            //Demonio centrado a la izquierda con empezar
            /*var introImageBounds = introImage.GetLocalBounds();
            introImage.Position = new Vector2f(((size.X - introImageBounds.Width) / 2f) - 128, ((size.Y - introImageBounds.Height) / 2f) + 170);
            var subtitleBounds = subtitleText.GetLocalBounds();
            subtitleText.Position = new Vector2f(((size.X - subtitleBounds.Width) / 2f) + 40, ((size.Y - subtitleBounds.Height) / 2f) + 158);*/

            var overlay = new RectangleShape(new Vector2f((size.X/2f) + 98 , (size.Y/7f) + 35))
            {
                Position = new Vector2f(((size.X - howPlayBounds.Width) / 2f) - 50, size.Y - howPlayBounds.Height - 65),
                FillColor = new Color(0, 0, 0, 180)
            };            

            target.Draw(backgroundSprite, states);
            target.Draw(overlay, states);
            target.Draw(titleText, states);
            target.Draw(misionText, states);
            target.Draw(descriptionText, states);
            target.Draw(subtitleText, states);
            target.Draw(howPlayText, states);
            target.Draw(introImage, states);
        }        
    }
}
