using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    class Bullet
    {
        Texture2D bulletTexture;
        Rectangle bulletRectangle;
        Color bulletColor;

        public Bullet(Texture2D bulletTexture,
            Rectangle bulletRectangle, Color bulletColor)
        {
            this.bulletTexture = bulletTexture;
            this.bulletRectangle = bulletRectangle;
            this.bulletColor = bulletColor;
        }

        public Texture2D BulletTexture
        {
            get { return bulletTexture; }

        }

        public Rectangle BulletRectangle
        {
            get { return bulletRectangle; }
        }

        public Color BulletColor
        {
            get { return bulletColor; }

        }

        public void moveBulletR()
        {
            bulletRectangle.X += 20;

        }

        public void moveBulletL()
        {
            bulletRectangle.X -= 20;

        }


    }
}
