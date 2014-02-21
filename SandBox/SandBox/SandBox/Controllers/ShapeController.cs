using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PhysicsSandbox.Shapes;

namespace SandBox.Controllers
{
    class ShapeController
    {
        List<Shape> Shapes = new List<Shape>();

        public void CreateShape(int selectedShape, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Vector2 position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Shape shape = null;
            //if (selectedShape == 1)
            //{
                shape = new PhysicsSandbox.Shapes.Rectangle(position);
            //}
            //if (selectedShape == 2)
            //{
            //    shape = new PhysicsSandbox.Shapes.Circle(position);
            //}
            //else if (selectedShape == 3)
            //{
            //    shape = new PhysicsSandbox.Shapes.Triangle(position);
            //}
            //Texture2D texture = new Texture2D(graphicsDevice, , 10);

            
            spriteBatch.Begin();
            //spriteBatch.Draw(texture, new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y, , Color.Aqua);
            //spriteBatch.Draw(texture, new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y, 10, 10), Color.Aqua);
            spriteBatch.End();
        }
    }
}
