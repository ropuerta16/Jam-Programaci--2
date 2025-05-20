using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    internal class Intro : StaticActor
    {
        private Font font,titleFont;
        public Intro() 
        {
            titleFont = new Font("Data/Fonts/Scratchy Lemon");
            font = new Font("Data/Fonts/osifont-gpl2fe");
        }
    }
}
