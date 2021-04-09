using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fproject
{
    public class Enemy
    {
        Texture2D enemyTexture;
        Rectangle enemyDisplay, enemySource;
        Color enemyColor;

        public int enemyHealth;

        public Enemy(Texture2D enemyTexture,
            Rectangle enemyDisplay, Rectangle enemySource,Color enemyColor, int enemyHealth )
        {
            this.enemyTexture = enemyTexture;
            this.enemyDisplay = enemyDisplay;
            this.enemySource = enemySource;
            this.enemyColor = enemyColor;
            this.enemyHealth = enemyHealth;
        }

        public Texture2D EnemyTexture
        {
            get { return enemyTexture; }

        }

        public Rectangle EnemyDisplay
        {
            get { return enemyDisplay; }
        }

        public Rectangle EnemySource
        {
            get { return enemySource; }
        }

        public Color EnemyColor
        {
            get { return enemyColor; }

        }



        public void animateEnemyXR(int newPosX)
        {
            if (enemySource.X < (enemySource.Width * 4))
            {
                enemySource.X += newPosX;
            }
            else
            {
                enemySource.X = 0;
            }

        }

        public void enemyMoveX(int speed)
        {
            enemyDisplay.X -= speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(enemyTexture, enemyDisplay, enemySource, enemyColor);
        }









    }
}
