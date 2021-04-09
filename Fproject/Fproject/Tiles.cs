using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    class Tiles
    {
        Texture2D tilesTexture;
        Rectangle tilesRectangle;
        Color tilesColor;

        public Tiles(Texture2D tilesTexture,
            Rectangle tilesRectangle, Color tilesColor)
        {
            this.tilesTexture = tilesTexture;
            this.tilesRectangle = tilesRectangle;
            this.tilesColor = tilesColor;
        }

        public Texture2D TilesTexture
        {
            get { return tilesTexture; }

        }

        public Rectangle TilesRectangle
        {
            get { return tilesRectangle; }
        }

        public Color TilesColor
        {
            get { return tilesColor; }

        }


    }
}
