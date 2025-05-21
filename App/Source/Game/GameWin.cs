﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    public class GameWin : StaticActor
    {
        private readonly string title = "YOU WIN";
        private readonly string playAgain = "R - VOLVER A JUGAR";
        private readonly string quit = "Q - EXIT";

        private Font font, titleFont;
        private Text titleText, playAgainText, quitText;
        private Color titleColor = Color.Black;
        private Color playAgainColor = Color.Blue;
        private Color quitColor = Color.White;
        private Sprite introImage;

        private Texture backgroundTexture;
        private Sprite backgroundSprite;


        public GameWin()
        {
            titleFont = new Font("Data/Fonts/Scratchy Lemon.ttf");
            font = new Font("Data/Fonts/osifont-lgpl3fe.ttf");

            titleText = new Text(title, titleFont, 250);
            titleText.FillColor = titleColor;

            playAgainText = new Text(playAgain, font, 40);
            playAgainText.FillColor = playAgainColor;

            quitText = new Text(quit, font, 38);
            quitText.FillColor = quitColor;

            introImage = new Sprite(new Texture("Data/Textures/Player/Character.png"));

            backgroundTexture = new Texture("Data/Textures/Background/MenusFondo.jpg");
            backgroundSprite = new Sprite(backgroundTexture);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            var window = Engine.Get.Window;
            var size = window.Size;

            var titleBounds = titleText.GetLocalBounds();
            titleText.Position = new Vector2f((size.X - titleBounds.Width) / 2f, 130);

            var playAgainBounds = playAgainText.GetLocalBounds();
            playAgainText.Position = new Vector2f((size.X - playAgainBounds.Width) / 2f, ((size.Y - playAgainBounds.Height) / 2f) + 10);

            var quitBounds = quitText.GetLocalBounds();
            quitText.Position = new Vector2f((size.X - quitBounds.Width) / 2f, ((size.Y - quitBounds.Height) / 2f) + playAgainBounds.Height + 30);


            backgroundSprite.Scale = new Vector2f((float)size.X / backgroundTexture.Size.X, (float)size.Y / backgroundTexture.Size.Y);
            backgroundSprite.Position = new Vector2f(0, 0);

            target.Draw(backgroundSprite, states);
            target.Draw(titleText, states);
            target.Draw(playAgainText, states);
            target.Draw(quitText, states);

            var imageBounds = introImage.GetLocalBounds();
            introImage.Position = new Vector2f((size.X - imageBounds.Width) / 2f, ((size.Y - quitBounds.Height) / 2f) + playAgainBounds.Height + 80);
            target.Draw(introImage, states);
        }
    }
}
