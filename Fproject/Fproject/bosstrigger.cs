using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    class bosstrigger
    {
        Texture2D triggerTexture;
        Rectangle triggerRectangle;
        Color triggerColor;

        public bosstrigger(Texture2D triggerTexture,
            Rectangle triggerRectangle, Color triggerColor)
        {
            this.triggerTexture = triggerTexture;
            this.triggerRectangle = triggerRectangle;
            this.triggerColor = triggerColor;
        }

        public Texture2D TriggerTexture
        {
            get { return triggerTexture; }

        }

        public Rectangle TriggerRectangle
        {
            get { return triggerRectangle; }
        }

        public Color TriggerColor
        {
            get { return triggerColor; }

        }


    }
}
