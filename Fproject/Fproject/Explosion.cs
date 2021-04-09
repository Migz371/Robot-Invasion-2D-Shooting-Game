using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    class Explosion
    {
        Texture2D explosionTexture;
        Rectangle explosionDisplay, explosionSource;
        Color explosionColor;

        public Explosion(Texture2D explosionTexture, Rectangle explosionDisplay, Rectangle explosionSource, Color explosionColor)
        {
            this.explosionTexture = explosionTexture;
            this.explosionDisplay = explosionDisplay;
            this.explosionSource = explosionSource;
            this.explosionColor = explosionColor;
        }

        public Texture2D ExplosionTexture
        {
            get { return explosionTexture; }
        }
        public Rectangle ExplosionDisplay
        {
            get { return explosionDisplay; }
        }
        public Rectangle ExplosionSource
        {
            get { return explosionSource; }
        }
        public Color ExplosionColor
        {
            get { return explosionColor; }
        }

        public void animateExplosionX(int newPosX)
        {
            if (explosionSource.X < (explosionSource.Width * 5))
            {
                explosionSource.X += newPosX;
            }



        }


    }
}
