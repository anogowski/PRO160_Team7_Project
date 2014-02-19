using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sandbox
{
    class Sprite
    {
        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float XVelocity
        {
            get;
            set;
        }

        public float YVelocity
        {
            get;
            set;
        }

        public float XAcceleration
        {
            get;
            set;
        }

        public float YAcceleration
        {
            get;
            set;
        }

        public Texture2D Texture
        {
            get;
            set;
        }

        public int currentFrame
        {
            get;
            set;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(X, Y);
            spriteBatch.Draw(Texture, position, Color.White);
        }

    }
}
