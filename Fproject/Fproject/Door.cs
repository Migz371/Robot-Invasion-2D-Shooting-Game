using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    class Door
    {
        Texture2D doorTexture;
        Rectangle doorRectangle;
        Color doorColor;

        public Door(Texture2D doorTexture,
            Rectangle doorRectangle, Color doorColor)
        {
            this.doorTexture = doorTexture;
            this.doorRectangle = doorRectangle;
            this.doorColor = doorColor;
        }

        public Texture2D DoorTexture
        {
            get { return doorTexture; }

        }

        public Rectangle DoorRectangle
        {
            get { return doorRectangle; }
        }

        public Color DoorColor
        {
            get { return doorColor; }

        }


    }
}
