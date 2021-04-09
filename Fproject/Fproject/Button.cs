using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Fproject
{
    class Button
    {
        Texture2D buttonTexture;
        Vector2 buttonPosition;
        Rectangle buttonRectangle;

        Color buttonColor = new Color(255, 255, 255, 255);

        public Vector2 size;

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            buttonTexture = newTexture;

            size = new Vector2(graphics.Viewport.Width / 4, 
                graphics.Viewport.Height / 6);

        }

        bool down;
        public bool isClicked;

            public void Update(MouseState mouse)
        {
            buttonRectangle = new Rectangle((int)buttonPosition.X,
                (int)buttonPosition.Y, (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if(mouseRectangle.Intersects(buttonRectangle))
            {
                if (buttonColor.A == 255) down = false;
                if (buttonColor.A == 0) down = true;
                if (down) buttonColor.A += 3; else buttonColor.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;


            }
            else if (buttonColor.A < 255)
            {
                buttonColor.A += 3;
                isClicked = false;
            }

        }

        public void setPosition(Vector2 newPosition)
        {
            buttonPosition = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, buttonRectangle, buttonColor);
        }


    }
}
